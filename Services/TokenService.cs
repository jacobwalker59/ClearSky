using System.Text;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ClearSky.Entities;
using ClearSky.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ClearSky.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        // private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration config)
        {
            _config = config;

        }
        public string CreateToken(AccountHolder user)
        {
             var claims = new List<Claim>
            {
               new Claim(JwtRegisteredClaimNames.NameId, user.UserName)
            };

            // create a new key here using super secret key, then add to app secret settings...
            var _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super secret key"));
            var creds = new SigningCredentials(_key,SecurityAlgorithms.HmacSha512Signature);
            // this is key right here

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds, 
                
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}