using Microsoft.AspNetCore.Mvc; // Provides attributes and base classes for building controllers and API endpoints
using Services; 
using Models; 

namespace Controllers
{
    // Indicates that this class is an API controller.
    // Enables automatic model validation, binding, and other API-specific behaviors.
    [ApiController]

    // Defines the base route for all actions in this controller.
    // [controller] is a placeholder replaced with the controller's name without "Controller" suffix.
    // In this case, route becomes "api/auth"
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;

        public AuthController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto dto)
        {
            var result = await _userService.RegisterAsync(dto.Username, dto.Email, dto.Password);
            if (!result) return BadRequest("Email already in use.");
            return Ok("User registered!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto dto)
        {
            var token = await _userService.LoginAsync(dto.Email, dto.Password);
            if (token == null) return Unauthorized("Invalid credentials.");

            // Set JWT as HttpOnly cookie
            Response.Cookies.Append("jwt", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true, // true in production (requires HTTPS)
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddHours(3)
            });

            return Ok(new { message = "Logged in successfully" });
        }
    }
}
