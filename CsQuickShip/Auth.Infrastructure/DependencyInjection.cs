
using Auth.Domain.Repositries;
using Auth.Infrastructure.DataBaseContext;
using Auth.Infrastructure.Repositries;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure;
public static class  DependencyInjection
{
    public static IServiceCollection AddInfrstructures(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository,UserRepository>();
        return services;
    }
    public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CsRegisterLoginIdentityDbContext>(options =>
        options.UseSqlServer(
        configuration.GetConnectionString("DefaultConnection")));
    }
}
