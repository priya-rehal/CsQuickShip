using Auth.Application.Command;
using Auth.Application.Constant;
using Auth.Application.Execptions;
using Auth.Application.Services;
using Auth.Domain.Entity.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Net;
using System.Security.Policy;
using static Auth.Application.Execptions.BusinessException;

namespace Auth.Application.CommandHandler;
public class ForgotPasswordCommandHandler(UserManager<ApplicationUser> _userManager, IEmailSender _emailSender, IOptions<AppSettings> _appSettings) : IRequestHandler<ForgotPasswordCommand, bool>
{
    public AppSettings Settings { get; private init; } = _appSettings.Value;

    public async Task<bool> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (string.IsNullOrEmpty(request._forgotPassword.Email)) throw new UserBusinessException(HttpStatusCode.BadRequest, "Request can't be null");

            ApplicationUser? existUser = await _userManager.FindByEmailAsync(request._forgotPassword.Email);

            if (existUser == null) throw new UserBusinessException(HttpStatusCode.NotFound, "No user exist with this email");

            string token = await _userManager.GeneratePasswordResetTokenAsync(existUser);
            if (!string.IsNullOrEmpty(token))
            {
                string callback = EmailCallBackFunction.GenerateCallbackUrl(Settings.FrontendUrl, request._forgotPassword.Email, token, UrlType.ForgetPassword);
                if (!string.IsNullOrEmpty(callback))
                {
                    bool response = await _emailSender.SendEmailAsync(
                                      request._forgotPassword.Email,
                                      EmailSubjects.ForgotPassword,
                                      $"{EmailBodyMessages.ForgotPasswordBody}{callback}");

                  return  response ? true : false;
                }
            }
            throw new UserBusinessException(HttpStatusCode.InternalServerError, "Something went wrong");
        }
        catch (Exception ex)
        {
            throw new BusinessException(HttpStatusCode.BadRequest, ex?.Message ?? ex?.InnerException?.Message);
        }
    }
}
