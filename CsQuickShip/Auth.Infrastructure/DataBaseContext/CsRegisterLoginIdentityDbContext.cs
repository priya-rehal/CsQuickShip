
using Auth.Domain.Entity.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.DataBaseContext;
public class CsRegisterLoginIdentityDbContext:IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    public CsRegisterLoginIdentityDbContext(DbContextOptions<CsRegisterLoginIdentityDbContext> options):base(options)
    {
        
    }
    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
}
