using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using SalesSystem.Modules.Users.Domain;
using Microsoft.Extensions.Configuration;
using SalesSystem.Modules.Users.Domain.Dto;
using SalesSystem.Modules.Users.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace SalesSystem.Modules.Users.Infrastructure
{
    public class GenerateToken : IGenerateToken
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;

        public GenerateToken(IConfiguration configuration, UserManager<User> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<TokenDto> GetToken(User user)
        {
            IList<string> roles = await _userManager.GetRolesAsync(user);

            List<Claim> claims = new()
            {
                new Claim("Email", user.Email!),
                new Claim("Id", user.Id.ToString()),
                new Claim("FullName", user.FullName!),
                new Claim(ClaimTypes.Role, roles.FirstOrDefault()!)
            };

            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_configuration["JwtConfig:jwtKey"]!));
            SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);
            DateTime experiration = DateTime.Now.AddDays(1);

            JwtSecurityToken token = new
            (
                issuer: null,
                audience: null,
                claims: claims,
                expires: experiration,
                signingCredentials: credentials
            );

            return new TokenDto { Token = new JwtSecurityTokenHandler().WriteToken(token), Expiration = experiration };
        }
    }
}
