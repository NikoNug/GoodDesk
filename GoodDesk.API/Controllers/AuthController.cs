using GoodDesk.API.Services;
using GoodDesk.ViewModel.Auth;
using Microsoft.AspNetCore.Mvc;

namespace GoodDesk.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] VMLoginRequest request)
        {
            var result = await _authService.LoginAsync(request);
            if(result == null)
            {
                return Unauthorized(new
                {
                    message = "Invalid username or password."
                });
            }

            return Ok(result);
        }
    }
}
