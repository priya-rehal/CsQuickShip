using Auth.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Command;
public class RefreshTokenCommand:IRequest<LoginResultDto>
{
    public   readonly TokenDto _tokenDto;
    public RefreshTokenCommand(TokenDto tokenDto)
    {

        _tokenDto = tokenDto;

    }
}
