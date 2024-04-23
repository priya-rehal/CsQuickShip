using Auth.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application;
public class RefreshTokenHelper
{
    public RefreshTokenDto GenerateRefreshToken()
    {
        RefreshTokenDto refreshToken = new RefreshTokenDto()
        {
            Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
            Expired = DateTime.Now.AddDays(1)
        };
        return refreshToken;
    }
}
