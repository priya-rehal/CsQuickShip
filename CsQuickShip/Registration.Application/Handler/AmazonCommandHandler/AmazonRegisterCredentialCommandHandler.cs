using MediatR;
using Registration.Application.Commands.Amazon;
using Registration.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Application.Handler.AmazonCommandHandler;
internal class AmazonRegisterCredentialCommandHandler : IRequestHandler<AmazonRegisterCredentialCommand, RegisterCredentialResponse>
{
    public Task<RegisterCredentialResponse> Handle(AmazonRegisterCredentialCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
