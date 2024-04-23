using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackShip.Domain.Repositries;
using TrackShip.Infrastructure.Repositries;

namespace TrackShip.Infrastructure;
public static class DependencyInjection
{
    public static  IServiceCollection AddInfrstructure(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
    public static void AddDbContext(this IServiceCollection services ,IConfiguration configuration)
    {
     /*   services.AddDbContext<TrackShipDbContext>(options =>
        options.UseSqlServer(
       configuration.GetConnectionString("DefaultConnection")));*/
    }
}   
