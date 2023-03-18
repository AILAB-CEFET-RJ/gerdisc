using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using gerdisc.Data.Entities;
using Microsoft.IdentityModel.Tokens;

namespace gerdisc.Core.Services
{
    /// <summary>
    /// Generates a token.
    /// </summary>
    public static class TokenService
    {
        public static string GenerateJwtToken(this UserEntity user, RsaSecurityKey privateKeys)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.FirstName),
                    new Claim(ClaimTypes.Surname, user.LastName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(privateKeys, SecurityAlgorithms.RsaSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}