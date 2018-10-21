using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EMS.Data.GetModels;
using Microsoft.IdentityModel.Tokens;

namespace EMS.API.Ulities
{
    public class GetToken
    {
        public static GetTokenModel getToken(string role , string id , string name)
        {

            var claims = new[]
       {
                new Claim(JwtRegisteredClaimNames.Sub,role),
                new Claim(JwtRegisteredClaimNames.NameId, id),
                new Claim(JwtRegisteredClaimNames.UniqueName, name),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

            };

            var signingkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("creativesoftware@12345moratuwaproject"));

            var token = new JwtSecurityToken(
                issuer: "http://oec.com",
                audience: "http://oec.com",
                expires: DateTime.UtcNow.AddHours(1),
                claims: claims,
                signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(signingkey, SecurityAlgorithms.HmacSha256)



                );
            //    return Ok(new
            //    {
            //        token = new JwtSecurityTokenHandler().WriteToken(token),
            //        expiration = token.ValidTo
            //    });

            var toke = new JwtSecurityTokenHandler().WriteToken(token);
             var   expiration = token.ValidTo;

            var send = new GetTokenModel { Token=toke, Expiretion=expiration };
            // return new string[] { toke, expiration.ToString() };
            return send;

        }
    }
}
