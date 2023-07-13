using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using SalesSystem.Modules.Users.Domain;
using Microsoft.Extensions.Configuration;
using SalesSystem.Modules.Users.Domain.Dto;

namespace SalesSystem.Modules.Users.Infrastructure
{
    public class GenerateToken : IGenerateToken
    {
        private readonly IConfiguration _configuration;

        public GenerateToken(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TokenDto GetToken(User user)
        {
            List<Claim> claims = new()
            {
                new Claim("Email", user.Email!),
                new Claim("Id", user.Id.ToString()),
                new Claim("FullName", user.FullName!)
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
