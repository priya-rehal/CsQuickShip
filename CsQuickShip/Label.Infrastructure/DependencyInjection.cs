using Label.Domain.IRepository;
using Label.Infrastructure.DataContext;
using Label.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Label.Infrastructure;
public static class DependencyInjection
{
    public static void AddInfratructureDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITestRepository, TestRepository>();
    }
    public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString, sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                    3,
                    TimeSpan.FromSeconds(10),
                    null);
            }), ServiceLifetime.Transient, ServiceLifetime.Transient);
    }
}
