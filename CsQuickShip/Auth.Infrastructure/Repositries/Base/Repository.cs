
using Auth.Domain.Entity;
using Auth.Domain.Repositries.Base;
using Auth.Infrastructure.DataBaseContext;
using Microsoft.EntityFrameworkCore;


namespace Auth.Infrastructure.Repositries.Base;
public class Repository<TEntity, TPrimaryKey> : ReadOnlyRepository<TEntity, TPrimaryKey>,
         IRepository<TEntity, TPrimaryKey>
         where TEntity : class, IEntity<TPrimaryKey>
{
    public Repository(CsRegisterLoginIdentityDbContext context) : base(context)
    {
    }

    public virtual void Create(TEntity entity)
    {
        Context.Set<TEntity>().Add(entity);
    }

    public virtual void Update(TEntity entity)
    {
        Table.Attach(entity);
        Context.Entry(entity).State = EntityState.Modified;
    }

    public virtual void Save()
    {
        try
        {
            Context.SaveChanges();
        }
        catch (DbUpdateException e)
        {
            ThrowEnhancedValidationException(e);
        }
    }

    public virtual Task SaveAsync()
    {
        try
        {
            return Context.SaveChangesAsync();
        }
        catch (DbUpdateException e)
        {
            ThrowEnhancedValidationException(e);
        }

        return Task.FromResult(0);
    }
    protected virtual void ThrowEnhancedValidationException(DbUpdateException e)
    {
        throw new DbUpdateException(e.Message, e.InnerException);
    }
}
