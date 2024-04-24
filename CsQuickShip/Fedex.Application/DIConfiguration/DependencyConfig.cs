
using Fedex.Application.ClientFactory;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Fedex.Application.DIConfiguration;
public static class DependencyConfig
{
    public static void AddApplicationDI(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IBaseClientFactory<,>), typeof(BaseClientFactory<,>));   
    }
}
