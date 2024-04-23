using Label.Domain.Entites;
using Label.Domain.IRepository;
using Label.Infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Label.Infrastructure.Repository;
public class TestRepository:BaseRepository<Test,int>,ITestRepository
{
    public TestRepository(ApplicationDbContext applicationDbContext):base(applicationDbContext)
    {
            
    }
}
