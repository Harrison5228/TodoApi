using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models.Request;
using TodoApi.Services.Interfaces;

namespace TodoApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    
    public class AuthController(IAuthService authService, ISessionService sessionService)
        : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest login)
        {
            await authService.Login(login.Username, login.Password);
            
            return Ok(new { username = login.Username, message = "Login successful" });
            
        }

        [HttpGet]
        public IActionResult GetUser()
        {
            return Ok(sessionService.GetSessionUser());
        }
        
    }
}