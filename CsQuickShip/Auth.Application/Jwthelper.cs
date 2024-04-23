using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application;
public class Jwthelper
{
    public Jwthelper(string tokenPhrase, IEnumerable<Claim> claims)
    {
        TokenPhrase = tokenPhrase;
        Claims = claims;
    }

    public string GetJwtToken()
    {
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        byte[] key = Encoding.ASCII.GetBytes(TokenPhrase);

        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new ClaimsIdentity(Claims),
            Expires = DateTime.UtcNow.AddSeconds(40),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
              SecurityAlgorithms.HmacSha256Signature)
        };

        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public string TokenPhrase { get; protected set; }
    public IEnumerable<Claim> Claims { get; protected set; }


}
