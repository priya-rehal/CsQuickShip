using FluentEmail.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Auth.Application.Services;
public class EmailSender(IFluentEmail _fluentEmail) : IEmailSender
{
    public void SendEmailAsync(string email, string subject, string body)
    {
        if (IsValid(email, subject, body))
        {
            ExecuteMailAsync(email, subject, body);
        }
    }
    private async void ExecuteMailAsync(string email, string subject, string body)
    {
        try
        {
            await _fluentEmail
               .To(email)
               .Subject(subject)
               .Body(body)
               .SendAsync();
        }
        catch (Exception cx)
        {
            throw new Exception(cx.Message, cx.InnerException);
        }
    }

    private bool IsValid(string email, string subject, string body)
    {
        return string.IsNullOrEmpty(email) || string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(body) ? false : true;
    }
}
