# Controller


#### now add a folder Controller, then add below class
###### AuthController.cs

```
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAdmin.Repositories;

namespace UserAdmin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenHandler tokenHandler;

        public AuthController(IUserRepository userRepository, ITokenHandler tokenHandler)
        {
            this.userRepository = userRepository;
            this.tokenHandler = tokenHandler;
        }

        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(string code, string password)
        {
            // Check if user is authenticated
            // Check username and password
            var user = await userRepository.AuthenticateAsync(code, password);

            if (user != null)
            {
                // Generate a JWT Token
                var token = await tokenHandler.CreateTokenAsync(user);
                return Ok(token);
            }

            return BadRequest("Username or Password is incorrect.");
        }
    }
}
```


###### UserController.cs

```
using Microsoft.AspNetCore.Mvc;
using UserAdmin.Repositories;

namespace UserAdmin.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;
        [HttpGet]
        [Route("Show")]
        public string GetMessage()
        {
            return "User Controller";
        }

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        [HttpGet]
        [Route("GetUserAsync")]
        public async Task<IActionResult> GetUserAsync(int user_id)
        {
            try
            {
                var user = await this.userRepository.GetUserAsync(user_id);
                return Ok(user);
            }
            catch (Exception Ex)
            {
                return BadRequest( Ex.Message.ToString());
            }
        }
    }
}

```