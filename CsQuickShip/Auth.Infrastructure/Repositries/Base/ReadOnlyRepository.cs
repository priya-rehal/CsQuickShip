
using Auth.Domain.Entity;
using Auth.Domain.Repositries.Base;
using Auth.Infrastructure.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Repositries.Base;
public class ReadOnlyRepository<TEntity, TPrimaryKey> : IReadOnlyRepository<TEntity, TPrimaryKey>
       where TEntity : class, IEntity<TPrimaryKey>
{
    protected readonly CsRegisterLoginIdentityDbContext Context;

    protected ReadOnlyRepository(CsRegisterLoginIdentityDbContext contextFactory)
    {
        Context = contextFactory;
    }

    protected DbSet<TEntity> Table => Context.Set<TEntity>();

    public virtual IEnumerable<TEntity> GetAll(
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string? includeProperties = null,
        int? skip = null,
        int? take = null
      )
    {
        return GetQueryable(null, orderBy, includeProperties, skip, take).ToList();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string? includeProperties = null,
        int? skip = null,
        int? take = null)
    {
        return await GetQueryable(null, orderBy, includeProperties, skip, take).ToListAsync();
    }

    public virtual IEnumerable<TEntity> Get(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string? includeProperties = null,
        int? skip = null,
        int? take = null)
    {
        return GetQueryable(filter, orderBy, includeProperties, skip, take).ToList();
    }
    public virtual async Task<IEnumerable<TEntity>> GetAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string? includeProperties = null,
        int? skip = null,
        int? take = null)
    {
        return await GetQueryable(filter, orderBy, includeProperties, skip, take).ToListAsync();
    }



    public virtual TEntity GetOne(
        Expression<Func<TEntity, bool>>? filter = null,
        string? includeProperties = null)
    {
        return GetQueryable(filter, null, includeProperties).SingleOrDefault();
    }

    public virtual async Task<TEntity> GetOneAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        string? includeProperties = null)
    {
        return await GetQueryable(filter, null, includeProperties).SingleOrDefaultAsync();
    }

    public virtual TEntity GetFirst(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string? includeProperties = null)
    {
        return GetQueryable(filter, orderBy, includeProperties).FirstOrDefault();
    }

    public virtual async Task<TEntity> GetFirstAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string? includeProperties = null)
    {
        return await GetQueryable(filter, orderBy, includeProperties).FirstOrDefaultAsync();
    }

    public virtual TEntity GetById(TPrimaryKey id)
    {
        return Table.Find(id);
    }

    public virtual async Task<TEntity> GetByIdAsync(TPrimaryKey id)
    {
        return await Table.FindAsync(id);
    }

    public virtual int GetCount(Expression<Func<TEntity, bool>>? filter = null)
    {
        return GetQueryable(filter).Count();
    }

    public virtual async Task<int> GetCountAsync(Expression<Func<TEntity, bool>>? filter = null)
    {
        return await GetQueryable(filter).CountAsync();
    }

    public virtual bool GetExists(Expression<Func<TEntity, bool>>? filter = null)
    {
        return GetQueryable(filter).Any();
    }

    public virtual async Task<bool> GetExistsAsync(Expression<Func<TEntity, bool>>? filter = null)
    {
        return await GetQueryable(filter).AnyAsync();
    }

    public virtual IEnumerable<TResult> GetProperties<TResult>(Func<TEntity, int, TResult> selector,
        Expression<Func<TEntity, bool>>? filter = null)
    {
        return GetQueryable().AsNoTracking().Select(selector);
    }

    public virtual Task<IEnumerable<TResult>> GetPropertiesAsync<TResult>(Func<TEntity, int, TResult> selector,
        Expression<Func<TEntity, bool>>? filter = null)
    {
        return Task.FromResult(
            GetQueryable(filter)
                .Select(selector)
        );
    }

    protected virtual IQueryable<TEntity> GetQueryable(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string? includeProperties = null,
        int? skip = null,
        int? take = null
        )
    {
        IQueryable<TEntity> query = Table;

        if (filter != null) query = query.Where(filter);

        if (includeProperties != null)
            query = includeProperties
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty.Trim()));

        if (orderBy != null) query = orderBy(query);

        if (skip.HasValue && skip.Value > 0) query = query.Skip(skip.Value);

        if (take.HasValue && take.Value > 0) query = query.Take(take.Value);
        return query;
    }
}
