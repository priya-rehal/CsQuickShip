﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Services;
public interface IEmailSender
{
    Task<bool> SendEmailAsync(string email, string subject, string body);
}
