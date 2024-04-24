using Label.Domain;
using Microsoft.EntityFrameworkCore;
using Label.Domain.IRepository;
using Label.Infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;

namespace Label.Infrastructure.Repository;
public class BaseRepository<TEntity, TPrimaryKey> : IBaseRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
{
    protected readonly ApplicationDbContext Context;
    internal DbSet<TEntity> dbSet;

    public BaseRepository(ApplicationDbContext applicationDbContext)
    {
        Context = applicationDbContext;
        dbSet = Context.Set<TEntity>();
    }
    public void Create(TEntity entity)
    {
        Context.Set<TEntity>().Add(entity);
        Context.SaveChanges();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null, string includeProperties = null)
    {
        IQueryable<TEntity> query = dbSet;
        if (filter != null)
            query = query.Where(filter);
        if (includeProperties != null)
        {
            foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProp);
            }
        }
        if (orderby != null)
            return await orderby(query).ToListAsync();
        return await query.ToListAsync();
    }
}
