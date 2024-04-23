using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Registration.Infrastructure.DatabaseContext;


namespace Registration.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
      
        return services;
    }
    public static void AddDbContext(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<RegistrationDbContext>(options =>
         options.UseSqlServer(
        configuration.GetConnectionString("DefaultConnection")));
    }
}
