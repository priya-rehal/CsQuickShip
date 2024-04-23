using MediatR;
using Registration.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Application.Queries;
public class GetAccessTokenQuery:IRequest<string>
{
    public string clientId { get; set; }
    public string clientSecret { get; set; }
    public GetAccessTokenQuery(string clientId, string clientSecret)
    {
        this.clientId = clientId;
        this.clientSecret = clientSecret;
    }
}
