using Microsoft.EntityFrameworkCore;
using Registration.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Infrastructure.DatabaseContext;
public class RegistrationDbContext:DbContext
{
    public RegistrationDbContext(DbContextOptions<RegistrationDbContext>options):base(options)
    {
        
    }
    public DbSet<Customer> Customers { get; set; }
}
