using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Entity.Identity;
public class ApplicationUser : IdentityUser<Guid>, IEntity<Guid>
{
    public string? ContactNo { get; set; }
    public string? CompanyName { get; set; }
    public string? RefreshToken {  get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
}
