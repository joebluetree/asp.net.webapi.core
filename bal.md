# Business Access Layer


## Create a standard project library namely UserAdmin
#### now add a folder Repositories, then add below class
###### IUserRepository.cs
```
using Database.models;
namespace UserAdmin.Repositories
{
   public interface  IUserRepository
    {
        Task<userm?> AuthenticateAsync(string username, string password);
        Task<userm?> GetUserAsync(int user_id);
    }

}

```

#### add below class to store token handler interface
###### ITokenHandler.cs

```
using Database.models;
namespace UserAdmin.Repositories
{
    public interface ITokenHandler
    {
        Task<string> CreateTokenAsync(userm user);
    }
}

```

#### Now add below class to handle User Tables CRUD operations
###### UserRepository.cs
```
using Microsoft.EntityFrameworkCore;
using Database;
using Database.models;

namespace UserAdmin.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<userm?> AuthenticateAsync(string username, string password)
        {

            var user = await appDbContext.Userm
                .FirstOrDefaultAsync(x => x.user_code.ToLower() == username.ToLower() && x.user_password == password);

            if (user == null)
            {
                return null;
            }

            /*
            var userRoles = await AppDbContext.Users_Roles.Where(x => x.UserId == user.Id).ToListAsync();
            if (userRoles.Any())
            {
                user.Roles = new List<string>();
                foreach (var userRole in userRoles)
                {
                    var role = await nZWalksDbContext.Roles.FirstOrDefaultAsync(x => x.Id == userRole.RoleId);
                    if (role != null)
                    {
                        user.Roles.Add(role.Name);
                    }
                }
            }
            */
            user.user_password = string.Empty;
            return user;
        }

        public async Task<userm?> GetUserAsync(int user_id)
        {
            var user = await appDbContext.Userm.FirstOrDefaultAsync(x => x.user_id == user_id);
            if (user == null)
                return null;
            return user;
        }
    }
}

```



#### add below class to create JWT Token
###### TokenHandler.cs

```

using Database.models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace UserAdmin.Repositories
{
    public class TokenHandler : ITokenHandler
    {

        private readonly IConfiguration configuration;

        public TokenHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Task<string> CreateTokenAsync(userm user)
        {
            // Create Claims
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.GivenName, user.user_code));
            claims.Add(new Claim(ClaimTypes.Surname, user.user_name));
            claims.Add(new Claim(ClaimTypes.Email, user.user_email));

            // Loop into roles of users
            /*
            user.Roles.ForEach((role) =>
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            });
            */

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }

    }
}

```
