using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Application.ErrorDto;
public class ErrorResponse
{
    public string ErrorCode { get; set; }
    public string ErrorDescription { get; set; }
    public string Message { get; set; }
}
