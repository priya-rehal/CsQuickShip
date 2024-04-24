using Auth.Application;
using Auth.Application.Command;
using Auth.Application.Constant;
using Auth.Application.DTO;
using Auth.Domain.Entity.Identity;
using Auth.Domain.Repositries;
using AutoMapper;
using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CsRegistrationLogin.Application.CommandHandler;
public class RegistrationCommandHandler : IRequestHandler<RegistrationCommand, string>
{
    private readonly IMapper _mapper;
    private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _userManager;
    private readonly Microsoft.AspNetCore.Identity.RoleManager<ApplicationRole> _roleManager;
    private readonly AppSettings _appSettings;
    private readonly IUserRepository _userRepository;
    public RegistrationCommandHandler(IMapper mapper, Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager, Microsoft.AspNetCore.Identity.RoleManager<ApplicationRole> roleManager, IOptions<AppSettings> appSettings, IUserRepository userRepository)
    {
        _mapper = mapper ?? throw new ArgumentNullException();
        _appSettings = appSettings.Value;
        _roleManager = roleManager ?? throw new ArgumentNullException();
        _userManager = userManager ?? throw new ArgumentNullException();
        _userRepository = userRepository ?? throw new ArgumentNullException();
    }
    public async Task<string> Handle(RegistrationCommand request, CancellationToken cancellationToken)
    {
        if (request._userDto == null)
        {
            throw new ArgumentNullException(nameof(request._userDto), "UserDto cannot be null");
        }

        try
        {
            ApplicationUser applicationUser = _mapper.Map<ApplicationUser>(request._userDto);

            ApplicationUser existingUser = await _userRepository.GetFirstAsync(u => u.Email == applicationUser.Email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("User with this email already exists");
            }

            if (string.IsNullOrWhiteSpace(request._userDto.Password))
            {
                throw new InvalidOperationException("Password cannot be null or empty");
            }

            applicationUser.PasswordHash = request._userDto.Password ?? throw new InvalidOperationException("Password cannot be null");
            Microsoft.AspNetCore.Identity.IdentityResult result = await _userManager.CreateAsync(applicationUser, applicationUser.PasswordHash);

            if (result.Succeeded)
            {
                await EnsureRolesExist(); // Ensure roles exist in the database

                var roleName = request._userDto.Role == Constant.Admin ? Constant.Admin : Constant.User;
                await _userManager.AddToRoleAsync(applicationUser, roleName);
            }
            else
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException($"Failed to create user: {errors}");
            }

            ApplicationUserDto createdUserDto = _mapper.Map<ApplicationUserDto>(applicationUser);
            return "added";
        }
        catch (Exception ex)
        {
            // Log the exception here
             throw new InvalidOperationException("An error occurred while registering the user", ex);
             // Rethrow the exception to maintain the original exception stack trace
        }
    }

    private async Task EnsureRolesExist()
    {
        string[] roles = new[] { Constant.Admin, Constant.User };
        foreach (var roleName in roles)
        {
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                await _roleManager.CreateAsync(new ApplicationRole(roleName));
            }
        }
    }

}
