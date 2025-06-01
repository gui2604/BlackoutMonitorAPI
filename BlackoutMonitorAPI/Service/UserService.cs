using BlackoutMonitorAPI.Data;
using BlackoutMonitorAPI.DTOs;
using BlackoutMonitorAPI.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlackoutMonitorAPI.Service
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;
        private readonly PasswordHasher<User> _hasher = new();

        public UserService(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<User> RegisterAsync(UserRegisterDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
                throw new Exception("Usuário já existe");

            var user = new User
            {
                Email = dto.Email,
                PasswordHash = _hasher.HashPassword(null, dto.Password) // Pass 'null' for the user parameter as it is not used in this context
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<string> LoginAsync(UserLoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null)
                throw new Exception("Usuário não encontrado");

            var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result == PasswordVerificationResult.Failed)
                throw new Exception("Senha incorreta");

            return GenerateToken(user);
        }

        private string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
