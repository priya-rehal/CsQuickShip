using Auth.Domain.Entity.ConfigurationModels;
using CsRegistrationLogin.Application.Mapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Auth.Application.Services;
using FluentEmail.Core;

namespace CsRegistrationLogin.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        services.AddAutoMapper(typeof(MappingProfile).Assembly);
        services.AddScoped<IEmailSender, EmailSender>();
        return services;
    }
    public static void AddEmailNotifications(this IServiceCollection services, IConfiguration configuration)
    {
        EmailSettings emailSettings = new();
        configuration.Bind(EmailSettings.Section, emailSettings);

        services
            .AddFluentEmail(emailSettings.DefaultFromEmail)
            .AddSmtpSender(new SmtpClient(emailSettings.PrimaryDomain)
            {
                Port = emailSettings.PrimaryPort,
                EnableSsl = true,
                Credentials = new NetworkCredential(
                    emailSettings.Username,
                    emailSettings.Password),
            });
    }
}
