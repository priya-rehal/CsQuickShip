using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Entity
{
    public interface IEntity<TPrimaryKey>
    {
        TPrimaryKey Id { get; }
    }
}
