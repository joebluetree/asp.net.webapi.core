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
