using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ClientFactory;
public interface IBaseClientFactory<TRequest, TResponse> where TRequest : class where TResponse : class
{
    Task<TResponse> SendAsync(string urlPath, TRequest requestbody, HttpMethod httpMethod, CancellationToken cancellationToken);
    TResponse Send(string urlPath, TRequest requestbody, HttpMethod httpMethod, CancellationToken cancellationToken);
}
