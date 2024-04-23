using Auth.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Command;
public class LoginCommand:IRequest<LoginResultDto>
{
	public LoginDto _login { get; set; }
	public LoginCommand(LoginDto login)
	{
		_login = login;
	}
}
