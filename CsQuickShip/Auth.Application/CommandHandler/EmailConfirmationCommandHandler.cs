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
internal class EmailConfirmationCommandHandler(
    UserManager<ApplicationUser> _userManager
    ) : IRequestHandler<EmailConfirmationCommand, bool>
{
    public async Task<bool> Handle(EmailConfirmationCommand request, CancellationToken cancellationToken)
    {
        if (request.resetPassword == null)
            throw new ArgumentNullException(nameof(request.resetPassword));
        try
        {
            ApplicationUser? existuser = await _userManager.FindByEmailAsync(request.resetPassword.Email);
            if (existuser != null)
            {
                IdentityResult confirm = await _userManager.ConfirmEmailAsync(existuser, request.resetPassword.Token);
                return (confirm.Succeeded) ? true : false;
            }
            throw new Exception("Invalid user please ! Enter valid credential");
        }
        catch (Exception)
        {
            throw;
        }
    }
}
