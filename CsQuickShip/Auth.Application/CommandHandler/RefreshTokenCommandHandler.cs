using Auth.Application.Command;
using Auth.Application.DTO;
using Auth.Domain.Entity.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Auth.Application.CommandHandler;
public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, LoginResultDto>
{
    private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly AppSettings _appSettings;
    public RefreshTokenCommandHandler(Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<AppSettings> appSettings)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _appSettings = appSettings.Value;
    }

    public async Task<LoginResultDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request._tokenDto is null)
            {
                throw new ArgumentNullException(nameof(request), "Invalid client request");
            }
            var principal = GetPrincipalFromExpiredToken(request._tokenDto.AccessToken ?? string.Empty);
            var username = principal?.Identity?.Name;
            if (string.IsNullOrEmpty(username))
            {
                throw new InvalidOperationException("Username not found in the token");
            }
            var user = await _userManager.FindByNameAsync(username);
            if (user is null)
            {
                throw new InvalidOperationException("User not found");
            }
           if (user is null || user.RefreshToken != request._tokenDto.RefreshToken || user.RefreshTokenExpiryTime < DateTime.UtcNow)
            {
                throw new Exception("Invalid refresh token");
            }
            
             // Generate new access token and refresh token
           string newAccessToken = new Jwthelper(_appSettings.TokenPhrase ?? string.Empty, principal?.Claims).GetJwtToken();
            RefreshTokenDto newRefreshToken = new RefreshTokenHelper().GenerateRefreshToken();
            // Update the user's refresh token in the database
            user.RefreshToken = newRefreshToken.Token;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(1); // Set a new expiration time for the refresh token
            await _userManager.UpdateAsync(user);

            return new LoginResultDto()
            {
                JwtAccessToken = newAccessToken,
                RefreshToken = newRefreshToken.Token
            };
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while processing the refresh token", ex);
        }
    }
    /// <summary>
    /// GetPrincipalFromExpiredToken method for extract the claims into the expiredtoken
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    /// <exception cref="SecurityTokenException"></exception>
    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.TokenPhrase ?? string.Empty)),
            ValidateLifetime = false
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken securityToken;
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
        var jwtSecurityToken = securityToken as JwtSecurityToken;

        if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        {
            throw new SecurityTokenException("Invalid token");
        }

        return principal;
    }
}
