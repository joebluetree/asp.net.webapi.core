using Microsoft.AspNetCore.Mvc;
using UserAdmin.Repositories;

namespace UserAdmin.Controllers
{
    [ApiController]
    [Route("Auth")]
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
            try
            {
                var user = await userRepository.AuthenticateAsync(code, password);
                if (user != null)
                {
                    // Generate a JWT Token
                    var token = await tokenHandler.CreateTokenAsync(user);
                    Dictionary<string, object> data = new Dictionary<string, object>();
                    data.Add("user_id", user.user_id);
                    data.Add("user_code", user.user_code);
                    data.Add("user_name", user.user_name);
                    data.Add("user_email", user.user_email);
                    data.Add("user_is_admin", user.user_is_admin);
                    data.Add("token", token);
                    return Ok(data);
                }
                return Unauthorized("Invalid User Name/Password");
            }
            catch (Exception ex )
            {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}
