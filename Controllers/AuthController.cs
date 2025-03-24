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

            // generally we will check with DB values, but I am giving here static data
            if (model.Email == "4usrinadh@gmail.com" && model.Password == "Password@1627")
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
            // add jwt secret key in appsetting, so that at required places we can use from one place, and also if we need to update these keys on server,
            // we can easily do in appsettings
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Jwt:Secret"));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.Email, email),
            new Claim(ClaimTypes.Role, "User")  
        };

            var token = new JwtSecurityToken(
                issuer: "who-is-issuing-this add here",
                audience: "Audience need to add here",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60), // adding 1 hour expiration for token
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
