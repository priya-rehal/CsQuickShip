using Auth.Api.Models;
using Auth.Application;
using Auth.Domain.Entity.Identity;
using Auth.Infrastructure.DataBaseContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text;
using Auth.Infrastructure;

namespace Auth.Api;

public static class DependecyRoot
{

    private static readonly string _allowSpecificOrigin = "MyPolicy";
    public static void AddDependency(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        services.Configure<AppSettings>(configuration.GetSection("AppSettings"));

        /*Enable CORS*/
        services.AddCors(options => options.AddPolicy(_allowSpecificOrigin, builder =>
        {
            builder.WithOrigins("https://localhost:4200").AllowAnyMethod().AllowAnyHeader();
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        }));
        services.AddInfrstructures().AddDbContext(configuration);
        services.AddIdentity<ApplicationUser, ApplicationRole>()
                   .AddDefaultTokenProviders()/*the token providers have nothing to do with token authentication: they are exclusively used to generate opaque tokens for account operations (like password reset or email change) and two-factor authentication.*/
                   .AddEntityFrameworkStores<CsRegisterLoginIdentityDbContext>()
                   .AddUserStore<UserStore<ApplicationUser, ApplicationRole, CsRegisterLoginIdentityDbContext, Guid>>() /*The user store or the identity store is a repository of user accounts and credentials.The Server connects to the user store to authenticate a user requesting access to a resource.*/
                   .AddRoleStore<RoleStore<ApplicationRole, CsRegisterLoginIdentityDbContext, Guid>>();


    }
    public static void AddJwtAuthentications(this IServiceCollection services, WebApplicationBuilder builder)
    {
        byte[] key = Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("AppSettings:TokenPhrase"));

        /*Add Authenticaton*/
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
           .AddJwtBearer(config =>
           {
               config.RequireHttpsMetadata = false;
               config.SaveToken = true;

               config.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(key),
                   ValidateIssuer = false,
                   ValidateAudience = false,
                   ValidateLifetime = true,
               };
           });
    }
}
