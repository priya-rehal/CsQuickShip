﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.DTO;
public class ForgotPasswordDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } 
}
