using Auth.Application.Command;
using Auth.Application.DTO;
using Auth.Domain.Entity.Identity;
using Auth.Domain.Repositries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Data.Entity.Core.Metadata.Edm;
using System.Security.Claims;


namespace Auth.Application.CommandHandler;
public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResultDto>
{
    private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _userManager;
    private readonly IUserRepository _userRepository;
    private readonly AppSettings _appsettings;
    private readonly IMapper _mapper;
    private readonly SignInManager<ApplicationUser> _signInManager;
    public LoginCommandHandler(Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager, IUserRepository userRepository,
        IOptions<AppSettings> appSettings, IMapper mapper, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _userRepository = userRepository;
        _mapper = mapper;
        _signInManager = signInManager;
        _appsettings = appSettings.Value;
    }
    /// <summary>
    /// gandle command for login the user
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<LoginResultDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        if (request._login == null)
        {
            throw new ArgumentNullException(nameof(request._login));
        }

        LoginResultDto resultDto = new LoginResultDto();

        try
        {
            ApplicationUser? applicationUser = await _userRepository.GetFirstAsync(u => u.Email == request._login.Email);

            if (applicationUser == null)
            {
                throw new InvalidOperationException("Incorrect username or password");
            }

            SignInResult loginResult = await _signInManager.PasswordSignInAsync(applicationUser, request._login.Password, true, false);

            if (!loginResult.Succeeded)
            {
                throw new InvalidOperationException("Incorrect username or password");
            }
            if (applicationUser != null)
            {
                List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, applicationUser?.UserName ?? string.Empty),
                new Claim(ClaimTypes.Email, applicationUser?.Email ?? string.Empty)
            };

                IList<string> roles = await _userManager.GetRolesAsync(applicationUser);

                if (roles.Any())
                {
                    claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
                }

                // Generate JWT token with claims
                resultDto.JwtAccessToken = new Jwthelper(_appsettings?.TokenPhrase ?? string.Empty, claims).GetJwtToken();

                RefreshTokenDto refreshTokenDto = new RefreshTokenHelper().GenerateRefreshToken();
                resultDto.RefreshToken = refreshTokenDto.Token;

                if (applicationUser.RefreshToken != refreshTokenDto.Token || applicationUser.RefreshTokenExpiryTime <= DateTime.Now)
                {
                    applicationUser.RefreshToken = refreshTokenDto.Token;
                    applicationUser.RefreshTokenExpiryTime = DateTime.Now.AddDays(1); // Set the expiry time for 7 days
                    await _userManager.UpdateAsync(applicationUser);
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        return resultDto;
    }
}


