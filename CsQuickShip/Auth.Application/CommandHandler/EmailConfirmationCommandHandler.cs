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
internal class EmailConfirmationCommandHandler(UserManager<ApplicationUser> _userManager) : IRequestHandler<EmailConfirmationCommand, bool>
{
    public async Task<bool> Handle(EmailConfirmationCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request == null)
                throw new UserBusinessException(HttpStatusCode.BadRequest, "Request can't be null");
            ApplicationUser? existuser = await _userManager.FindByEmailAsync(request.EmailConfirm.Email);
            if (existuser != null)
            {
                IdentityResult confirm = await _userManager.ConfirmEmailAsync(existuser, request.EmailConfirm.Token.Replace(" ", "+"));
                return (confirm.Succeeded) ? true : false;
            }
            throw new UserBusinessException(HttpStatusCode.NotFound, "No User found with this email");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
