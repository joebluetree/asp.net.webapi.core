# Business Access Layer


## Create a standard project library namely UserAdmin
#### now add a folder Repositories, then add below class

###### iUserRepository.cs
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

#### Now add below class
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

