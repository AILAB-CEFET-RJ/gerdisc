using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using gerdisc.Models.Entities;
using gerdisc.Models.Enums;
using Microsoft.IdentityModel.Tokens;

namespace gerdisc.Infrastructure.Providers
{
    /// <summary>
    /// Generates a token.
    /// </summary>
    public static class TokenProvider
    {
        public static string GenerateJwtToken(this UserEntity user, RsaSecurityKey privateKeys)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()??""),
                    new Claim(ClaimTypes.Name, user.FirstName??""),
                    new Claim(ClaimTypes.Surname, user.LastName??""),
                    new Claim(ClaimTypes.Email, user.Email??""),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(privateKeys, SecurityAlgorithms.RsaSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public static string GenerateResetPasswordJwt(this UserEntity user, RsaSecurityKey privateKeys, DateTime ExpireDate)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()??""),
                    new Claim(ClaimTypes.Name, user.FirstName??""),
                    new Claim(ClaimTypes.Surname, user.LastName??""),
                    new Claim(ClaimTypes.Email, user.Email??""),
                    new Claim(ClaimTypes.Role, RolesEnum.ResetPassword.ToString())
                }),
                Expires = ExpireDate,
                SigningCredentials = new SigningCredentials(privateKeys, SecurityAlgorithms.RsaSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}