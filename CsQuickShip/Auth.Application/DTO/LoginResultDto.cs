using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.DTO;
public class LoginResultDto
{
   /* public Guid Id { get; set; }
    /// <summary>
    /// username of user
    /// </summary>
    public string? UserName { get; set; }
    /// <summary>
    /// roles of user
    /// </summary>
    public IList<string>? Roles { get; set; }
    /// <summary>
    /// jwt token
    /// </summary>*/
    public string? JwtAccessToken { get; set; }
    public string? RefreshToken { get; set; }

}
