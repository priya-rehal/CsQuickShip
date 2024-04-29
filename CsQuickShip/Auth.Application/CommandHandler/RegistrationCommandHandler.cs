using Auth.Application;
using Auth.Application.Command;
using Auth.Application.Constant;
using Auth.Application.DTO;
using Auth.Application.Services;
using Auth.Domain.Entity.Identity;
using Auth.Domain.Repositries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Auth.Application.Execptions.BusinessException;

namespace CsRegistrationLogin.Application.CommandHandler;
public class RegistrationCommandHandler : IRequestHandler<RegistrationCommand, string>
{
    private readonly IMapper _mapper;
    private readonly IEmailSender _emailSender;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly AppSettings _appSettings;
    private readonly IUserRepository _userRepository;
    public RegistrationCommandHandler(IMapper mapper, IEmailSender emailSender,
                    UserManager<ApplicationUser> userManager,
                    RoleManager<ApplicationRole> roleManager,
                    IOptions<AppSettings> appSettings,
                    IUserRepository userRepository)
    {
        _emailSender = emailSender;
        _mapper = mapper ?? throw new ArgumentNullException();
        _appSettings = appSettings.Value;
        _roleManager = roleManager ?? throw new ArgumentNullException();
        _userManager = userManager ?? throw new ArgumentNullException();
        _userRepository = userRepository ?? throw new ArgumentNullException();
    }
    public async Task<string> Handle(RegistrationCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request._userDto == null)
            {
                throw new UserBusinessException(HttpStatusCode.BadRequest, "request can't be null");
            }
            if (string.IsNullOrWhiteSpace(request._userDto.Password))
            {
                throw new UserBusinessException(HttpStatusCode.BadRequest,"Password cannot be null or empty");
            }
            ApplicationUser existingUser = await _userRepository.GetFirstAsync(u => u.Email == request._userDto.Email);
            if (existingUser == null)
            {
                ApplicationUser applicationUser = _mapper.Map<ApplicationUser>(request._userDto);

                applicationUser.PasswordHash = request._userDto.Password;
                IdentityResult result = await _userManager.CreateAsync(applicationUser, applicationUser.PasswordHash);

                if (result.Succeeded)
                {
                    await EnsureRolesExist(); // Ensure roles exist in the database

                    var roleName = request._userDto.Role == Constant.Admin ? Constant.Admin : Constant.User;  //Assigning role to user
                    await _userManager.AddToRoleAsync(applicationUser, roleName);

                    //Sending confirmaiton mail
                    string emailconfirmationtoken = await _userManager.GenerateEmailConfirmationTokenAsync(applicationUser);
                    if (string.IsNullOrEmpty(emailconfirmationtoken)) { throw new UserBusinessException(HttpStatusCode.InternalServerError, "Something went wrong"); }

                    string callback_url = EmailCallBackFunction.GenerateCallbackUrl(_appSettings?.FrontendUrl, request._userDto.Email,
                                                                emailconfirmationtoken, UrlType.EmailConfirmation);
                    if (string.IsNullOrEmpty(callback_url)) { throw new UserBusinessException(HttpStatusCode.InternalServerError, "Something went wrong"); }

                    _ = Task.Run(async () =>
                    {
                        await _emailSender.SendEmailAsync(
                                     request._userDto.Email,
                                     EmailSubjects.ConfirmEmail,
                                     $"{EmailBodyMessages.ConfirmEmailBody}{callback_url}");
                    });
                }
                else
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    throw new InvalidOperationException($"Failed to create user: {errors}");
                }

                ApplicationUserDto createdUserDto = _mapper.Map<ApplicationUserDto>(applicationUser);
                return "added";
            }
            throw new UserBusinessException(HttpStatusCode.InternalServerError,"Something went wrong");
        }
        catch (Exception ex)
        {
            // Log the exception here
            throw new Exception(ex.Message);
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
