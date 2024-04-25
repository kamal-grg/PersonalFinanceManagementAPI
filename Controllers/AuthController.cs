using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PersonalFinanceManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly PersonalFinanceManagementDBContext _context;
        private IConfiguration _config;
        public AuthController(IConfiguration config, PersonalFinanceManagementDBContext context)
        {
            _config = config;
            _context = context;
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            // Authenticate user (check username and password against database, etc.)
            if (!Authenticate(username, password))
            {
                //return Unauthorized();
                return Ok(new AuthDtoResponse() { Success = false,
                ReadableMessage="Sorry credential not match",
                 Token=""
                }); ;
            }

            var token = GenerateToken(username);
            return Ok(new { token });
        }
        private bool Authenticate(string username, string password)
        {
            // Implement your authentication logic (e.g., querying the database)
            // Return true if authentication succeeds, false otherwise
            // Example: return _userService.ValidateCredentials(username, password);
            return _context.User.Any(u => u.Email == username && u.Password == password);

            
        }

        private string GenerateToken(string username)
        {
            var key = Encoding.ASCII.GetBytes("Hi welcome to MIU university which is located in fairfield Iowa"); // Use the same secret key used in ConfigureServices
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(1), // Token expiration time
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
