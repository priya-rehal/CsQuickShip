using MediatR;
using Microsoft.Win32;
using Registration.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Application.Commands;
public class GenricRegisterCommand:IRequest<RegisterCredentialResponse>
{
   public RegisterCredentialsRequestDto _register {  get; private set; }
    public GenricRegisterCommand(RegisterCredentialsRequestDto register)
    {
        _register = register?? throw new ArgumentNullException(nameof(register));
    }
}
