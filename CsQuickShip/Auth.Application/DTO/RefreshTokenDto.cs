using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.DTO;
public class RefreshTokenDto
{
    public required string Token { get; set; }
    public DateTime Created { get; set; }= DateTime.Now;

    public DateTime Expired { get; set; }
}
