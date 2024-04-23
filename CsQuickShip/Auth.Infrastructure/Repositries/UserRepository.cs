
using Auth.Domain.Entity.Identity;
using Auth.Domain.Repositries;
using Auth.Infrastructure.DataBaseContext;
using Auth.Infrastructure.Repositries.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Repositries;
public class UserRepository : Repository<ApplicationUser, Guid>, IUserRepository
{
    public UserRepository(CsRegisterLoginIdentityDbContext context) : base(context)
    {
    }
}
