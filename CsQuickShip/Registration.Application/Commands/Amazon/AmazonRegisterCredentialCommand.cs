using MediatR;
using Registration.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Application.Commands.Amazon;
public class AmazonRegisterCredentialCommand:IRequest<RegisterCredentialResponse>
{
    public RegisterCredentialsRequestDto _register { get; private set; }
	public AmazonRegisterCredentialCommand(RegisterCredentialsRequestDto register)
	{
		_register = register ?? throw new ArgumentNullException(nameof(register));
	}
}
