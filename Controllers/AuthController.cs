using ChronicDiseaseApplication.DTOs;
using ChronicDiseaseApplication.Services;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Serilog.Core;

namespace ChronicDiseaseApplication.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(AuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            var result = await _authService.RegisterUser(model);
            if (!result.Success) return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if (model == null || string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
            {
                return BadRequest(new { message = "Invalid login request" });
            }

            if (model.Email == "test@example.com" && model.Password == "Password123")
            {
                var token = GenerateJwtToken(model.Email);
                _logger.LogInformation($"User {model.Email} logged in successfully.");
                return Ok(new { token });
            }

            _logger.LogWarning($"Failed login attempt for {model.Email}");
            return Unauthorized(new { message = "Invalid credentials" });
        }
        private string GenerateJwtToken(string email)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSuperSecretKey123456!"));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.Email, email),
            new Claim(ClaimTypes.Role, "User")  // ✅ Can add roles if needed
        };

            var token = new JwtSecurityToken(
                issuer: "YourIssuer",
                audience: "YourAudience",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60), // ✅ 1-hour expiry
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
