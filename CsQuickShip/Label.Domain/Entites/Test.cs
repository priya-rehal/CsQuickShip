using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Label.Domain.Entites;
public class Test:IEntity<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
}
