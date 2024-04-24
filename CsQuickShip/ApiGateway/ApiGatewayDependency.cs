using Ocelot.Values;

namespace ApiGateway;

public static class Dependency {
    public static void ApiGatewayDependency(this IServiceCollection service, IConfiguration configuration)
    {
        /*Enable CORS*/
        service.AddCors(options => options.AddPolicy(name:"MyPolicy", builder =>
        {
            builder.WithOrigins("https://localhost:4200").AllowAnyMethod().AllowAnyHeader();
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        }));
    }

}

