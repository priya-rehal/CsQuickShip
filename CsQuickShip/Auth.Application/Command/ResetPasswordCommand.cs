using Auth.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Command;
public record ResetPasswordCommand(ResetPasswordDto _resetPassword):IRequest<bool>;

