using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Label.Domain.IRepository;
public interface IBaseRepository<TEntity,TPrimaryKey> where TEntity : class,IEntity<TPrimaryKey>
{
    void Create(TEntity entity);
    Task<IEnumerable<TEntity>> GetAllAsync(
              Expression<Func<TEntity, bool>> filter = null,
              Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null,
              string includeProperties = null    //category,covertype
              );
}
