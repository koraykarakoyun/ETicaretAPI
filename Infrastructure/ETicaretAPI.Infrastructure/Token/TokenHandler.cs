using ETicaretAPI.Application.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure.Token
{
    public class TokenHandler : ITokenHandler
    {

        IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Application.DTOs.Token CreateAccessToken(int expiration_time_seconds)
        {
            Application.DTOs.Token token = new Application.DTOs.Token();

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            token.Expiration = DateTime.UtcNow.AddSeconds(expiration_time_seconds);


            //Asıl olay bu sınıfta...(JWTSecurityToken)

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken
                (
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                notBefore: DateTime.UtcNow,
                expires: token.Expiration,
                signingCredentials: signingCredentials
                );

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            token.AccessToken = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

            return token;
        }
    }
}
