using Application.ClientFactory;
using Application.DTOMapping;
using Domain.ConfigurationModel;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.DIConfiguration;
public static class DependencyConfig
{
    public static void AddApplicationDI(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IBaseClientFactory<,>), typeof(BaseClientFactory<,>));   
    }
}
