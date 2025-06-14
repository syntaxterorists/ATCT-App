using ATCT_Backend.Data;
using ATCT_Backend.Models;
using ATCT_Backend.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;

namespace ATCT_Backend.Controllers
{
    // Defines this class as an API controller with route 'api/auth'

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // POST: api/auth/register

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            // Check if a user with the provided email already exists

            if (_context.Users.Any(u => u.Email == dto.Email))
                return BadRequest("Korisnik već postoji.");


            // Create a new User object with hashed password
            var user = new User
            {
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password), //Password is hashed
                FullName = dto.FullName
            };

            // Add the new user to the database
            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok("Korisnik registrovan.");
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {

            // Try to find the user by email

            var user = _context.Users.FirstOrDefault(u => u.Email == dto.Email);

            // If user not found or password doesn't match, return unauthorized

            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return Unauthorized("Neispravni podaci.");

            // If login is successful, generate JWT token and return it

            var token = GenerateJwtToken(user);
            return Ok(new { token });
        }


        // Helper method to generate a JWT token for the authenticated user
        private string GenerateJwtToken(User user)
        {

            // Define claims (user identity data) that will be stored in the token
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FullName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Create the token with expiration time, claims, issuer and audience

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
