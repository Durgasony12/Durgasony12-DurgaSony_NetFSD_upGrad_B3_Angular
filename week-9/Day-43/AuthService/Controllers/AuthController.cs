using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AuthService.Models;
using AuthService.Services;
namespace AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public List<UserModel> usersList = null;
        private readonly JwtService _jwtService;


        public AuthController(JwtService jwtService)
        {

            _jwtService = jwtService;

            usersList = new List<UserModel>()
            {
                new UserModel() { Email = "admin@gmail.com", Password = "Admin123", Role="Admin" },
                new UserModel() { Email = "scott@gmail.com", Password = "Scott123", Role="Default" }
            };
        }


        [HttpPost("Login")]
        public IActionResult Login(UserModel requestUser)
        {
            // 1. Verify the user credentials
            UserModel? userObj = usersList.FirstOrDefault(user => user.Email ==
            requestUser.Email && user.Password == requestUser.Password);

            if (userObj != null)
            {
                // 2. Generate JWT Token
                string tokenStr = _jwtService.GenerateJSONWebToken(userObj);
                return Ok(new { token = tokenStr });
            }
            else
            {
                return BadRequest("Invalid user id or password");
            }
        }
    }
}
