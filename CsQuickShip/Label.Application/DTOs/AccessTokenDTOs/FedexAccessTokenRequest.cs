using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Label.Application.DTOs.AccessTokenDTOs;
public class FedexAccessTokenRequest
{
    public string? grant_type { get; set; }
    public string? client_id { get; set; }
    public string? client_secret { get; set; }
}
