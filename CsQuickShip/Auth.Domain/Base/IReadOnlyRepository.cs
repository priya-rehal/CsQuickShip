
using Auth.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Repositries.Base;
public interface IReadOnlyRepository<TEntity, TPrimaryKey>
         where TEntity : IEntity<TPrimaryKey>
{
    IEnumerable<TEntity> GetAll(
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string? includeProperties = null,
        int? skip = null,
        int? take = null
     );


    Task<IEnumerable<TEntity>> GetAllAsync(
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string? includeProperties = null,
        int? skip = null,
        int? take = null);

    IEnumerable<TEntity> Get(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string? includeProperties = null,
        int? skip = null,
        int? take = null);

    Task<IEnumerable<TEntity>> GetAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string? includeProperties = null,
        int? skip = null,
        int? take = null);

    TEntity GetOne(
        Expression<Func<TEntity, bool>>? filter = null,
        string? includeProperties = null);

    Task<TEntity> GetOneAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        string? includeProperties = null);

    TEntity? GetFirst(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string? includeProperties = null);

    Task<TEntity> GetFirstAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string? includeProperties = null);

    TEntity GetById(TPrimaryKey id);

    Task<TEntity> GetByIdAsync(TPrimaryKey id);

    int GetCount(Expression<Func<TEntity, bool>>? filter = null);

    bool GetExists(Expression<Func<TEntity, bool>>? filter = null);

    Task<bool> GetExistsAsync(Expression<Func<TEntity, bool>>? filter = null);

    IEnumerable<TResult> GetProperties<TResult>(Func<TEntity, int, TResult> selector,
        Expression<Func<TEntity, bool>>? filter = null);

    Task<IEnumerable<TResult>> GetPropertiesAsync<TResult>(Func<TEntity, int, TResult> selector,
        Expression<Func<TEntity, bool>>? filter = null);
}


