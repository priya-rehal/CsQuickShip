using MediatR;
using Registration.Application.Commands;
using Registration.Application.Commands.Amazon;
using Registration.Application.Commands.FedEx;
using Registration.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Application.Handler;
public class GenricRegisterHandler : IRequestHandler<GenricRegisterCommand, RegisterCredentialResponse>
{
    private readonly ISender _sender;
    public GenricRegisterHandler(ISender sender)
    {
        _sender = sender?? throw new ArgumentNullException(nameof(sender));
    }
    public async Task<RegisterCredentialResponse> Handle(GenricRegisterCommand request, CancellationToken cancellationToken)
    {
        switch (request._register.Carrier)
        {
            case Carrier.Fedex:
                return await _sender.Send(new FedexRegisterCredentialCommand(request._register), cancellationToken);
            case Carrier.Amazon:
                return await _sender.Send(new AmazonRegisterCredentialCommand(request._register), cancellationToken);
            default:
                throw new ArgumentException("Invalid carrier");
        }
    }
}

