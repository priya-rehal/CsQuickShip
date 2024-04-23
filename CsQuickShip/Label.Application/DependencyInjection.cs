using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Label.Application;
public static class DependencyInjection
{
    public static void AddMediatr(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
        });
    }
    public static void AddApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
    {
    }
}
