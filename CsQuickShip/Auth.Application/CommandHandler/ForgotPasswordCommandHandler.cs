using Auth.Application.Command;
using Auth.Application.Constant;
using Auth.Application.Services;
using Auth.Domain.Entity.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Security.Policy;

namespace Auth.Application.CommandHandler;
internal class ForgotPasswordCommandHandler(
    UserManager<ApplicationUser> _userManager,
    IEmailSender _emailSender
    ) : IRequestHandler<ForgotPasswordCommand, bool>
{
    //private readonly UserManager<ApplicationUser> _userManager = _userManager;
    public async Task<bool> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request._forgotPassword.Email))
            throw new ArgumentNullException(nameof(request._forgotPassword.Email));
        try
        {
            ApplicationUser? existUser = await _userManager.FindByEmailAsync(request._forgotPassword.Email);
            if (existUser == null)
                throw new NotImplementedException();

            string token = await _userManager.GeneratePasswordResetTokenAsync(existUser);
            string callback = EmailCallBackFunction.GenerateCallbackUrl(
                              request._forgotPassword.Email,
                              token, UrlType.ForgetPassword);
            _ = Task.Run(() =>
            {
                _emailSender.SendEmailAsync(
                             request._forgotPassword.Email,
                             EmailSubjects.ForgotPassword,
                             $"{EmailBodyMessages.ForgotPasswordBody}{callback}");
            });
            return true;
        }
        catch (Exception ex)
        {
            throw;
        }

    }
}
