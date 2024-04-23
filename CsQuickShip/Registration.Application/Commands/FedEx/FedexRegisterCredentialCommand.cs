using MediatR;
using Registration.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Application.Commands.FedEx;
public class FedexRegisterCredentialCommand : IRequest<RegisterCredentialResponse>
{
    public RegisterCredentialsRequestDto _register { get; set; }
    public FedexRegisterCredentialCommand(RegisterCredentialsRequestDto register)
    {

        _register = register;

    }
}
