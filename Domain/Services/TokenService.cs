using Authentication;
using Entites;
using Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Domain.Services
{
    public static class TokenService
    {
        public static string SetToken(User usuario, IOptions<ConfigsSettings> config)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var keySecutity = config.Value.SecuretKey;
            var key = Encoding.ASCII.GetBytes(keySecutity);
            var tokenDescricao = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.FirstName.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescricao);

            return tokenHandler.WriteToken(token);
        }
    }
}

