using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SmartAcademyBackend.DTOs.UserDTO;
using SmartAcademyBackend.Entities;
using SmartAcademyBackend.Service.UserService;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SmartAcademyBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        
        [HttpPost("register")]
        public async Task<IActionResult> register(RegisterUserDTO newUser)
        {
           var registerUser = await authService.registerUser(newUser);
            if (registerUser is null)
                return BadRequest("User Exists");
            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> login(loginDTO requestUser)
        {
            Console.WriteLine("arrived");
            var loginUser = await authService.login(requestUser);
            if (loginUser is null)
                return BadRequest("Incorrect Email or Password");

            return Ok(loginUser);
               
        }

       


    }
}
