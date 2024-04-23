using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.DTO;
public class ApplicationUserDto
{
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? ContactNo {  get; set; }
    public string? CompanyName { get; set; }
    public string? Password { get; set; }
    public string? Role { get; set; }
}
