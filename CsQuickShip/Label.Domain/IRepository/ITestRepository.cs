using Label.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Label.Domain.IRepository;
public interface ITestRepository:IBaseRepository<Test,int>
{
}
