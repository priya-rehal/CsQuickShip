
using Auth.Domain.Entity;

namespace Auth.Domain.Repositries.Base;
public interface IRepository<TEntity, TPrimaryKey> : IReadOnlyRepository<TEntity, TPrimaryKey>
      where TEntity : class, IEntity<TPrimaryKey>
{
    void Create(TEntity entity);
    Task SaveAsync();
    void Update(TEntity entity);
    void Save();
}
