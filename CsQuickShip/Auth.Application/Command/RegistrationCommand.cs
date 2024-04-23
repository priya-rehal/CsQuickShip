using Auth.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Command;
public class RegistrationCommand:IRequest<ApplicationUserDto>
{
    public readonly ApplicationUserDto _userDto;
    public RegistrationCommand(ApplicationUserDto user)
    {

        _userDto = user;

    }
}
