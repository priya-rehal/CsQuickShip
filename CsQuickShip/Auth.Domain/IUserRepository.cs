
using Auth.Domain.Entity.Identity;
using Auth.Domain.Repositries.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Repositries;
public interface IUserRepository : IRepository<ApplicationUser, Guid>
{

}
