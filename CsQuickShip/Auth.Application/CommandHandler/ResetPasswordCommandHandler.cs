using Auth.Application.Command;
using Auth.Domain.Entity.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Auth.Application.Execptions.BusinessException;

namespace Auth.Application.CommandHandler;
internal class ResetPasswordCommandHandler(
    UserManager<ApplicationUser> _userManager
    ) : IRequestHandler<ResetPasswordCommand, bool>
{
    public async Task<bool> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request == null)
                throw new UserBusinessException(HttpStatusCode.BadRequest, "Request can't be null");

            ApplicationUser? userExist = await _userManager.FindByEmailAsync(request._resetPassword.Email);
            if (userExist == null)
                throw new UserBusinessException(HttpStatusCode.NotFound, "No user found with this email");

            IdentityResult result = await _userManager.ResetPasswordAsync(userExist,
                                            request._resetPassword.Token.Replace(" ", "+"),
                                            request._resetPassword.Password);
            return result == IdentityResult.Success ? true : false;
        }
        catch ( Exception ex )
        {
            throw new Exception(ex.Message);
        }

    }
}
