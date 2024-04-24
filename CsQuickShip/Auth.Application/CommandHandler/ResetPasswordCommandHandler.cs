using Auth.Application.Command;
using Auth.Domain.Entity.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.CommandHandler;
internal class ResetPasswordCommandHandler(
    UserManager<ApplicationUser> _userManager
    ) : IRequestHandler<ResetPasswordCommand, bool>
{
    public async Task<bool> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        if (request._resetPassword == null)
            throw new NotImplementedException();

        ApplicationUser? userExist = await _userManager.FindByEmailAsync(request._resetPassword.Email);
        if (userExist == null)
            throw new NotImplementedException();
        IdentityResult result = await _userManager.ResetPasswordAsync(userExist,
                                        request._resetPassword.Token,
                                        request._resetPassword.Password);
        return result == IdentityResult.Success ? true : false;

    }
}
