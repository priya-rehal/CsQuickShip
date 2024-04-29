using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Execptions;
public class BusinessException : Exception
{
    public HttpStatusCode StatusCode { get; set; }
    public string? Message { get; set; } = "";

    public BusinessException(HttpStatusCode httpStatusCode, string message) : base(message)
    {
        StatusCode = httpStatusCode;
        Message = message;
    }

    public class UserBusinessException : BusinessException
    {
        public IEnumerable<IdentityError> Errors { get; }

        public UserBusinessException(HttpStatusCode httpStatusCode, string message) : base(httpStatusCode, message)
        {

        }
    }
}
