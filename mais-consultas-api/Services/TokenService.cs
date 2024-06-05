using mais_consultas_api.Models;
using mais_consultas_api.Models.Options;
using mais_consultas_api.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace mais_consultas_api.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtOptions options;

        public TokenService(IOptions<JwtOptions> options)
        {
            this.options = options.Value;
        }

        public string GenerateToken(Patient patient)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(options.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = options.Issuer,
                Audience = options.Audience,
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Name", patient.Name),
                    new Claim("Email", patient.Email),
                    new Claim("Role", nameof(Patient))
                }),
                Expires = DateTime.UtcNow.AddSeconds(options.ExpiresInSeconds),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }        
    }
}
