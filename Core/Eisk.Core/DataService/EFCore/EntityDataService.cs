using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eisk.Core.DataService.EFCore;

public class EntityDataService<TEntity> : IEntityDataService<TEntity> where TEntity : class, new()
{
    protected readonly DbContext DbContext;

    public EntityDataService(DbContext dbContext)
    {
        DbContext = dbContext;
    }

    public virtual async Task<TEntity> GetById<TId>(TId id)
    {
        return await DbContext.Set<TEntity>().FindAsync(id);
    }

    public virtual async Task<IList<TEntity>> GetAll()
    {
        return await DbContext.Set<TEntity>().ToListAsync();
    }

    public virtual async Task<TEntity> Add(TEntity entity)
    {
        var obj = DbContext.Add(entity);
;
        await DbContext.SaveChangesAsync();

        return obj.Entity;
    }

    public virtual async Task<TEntity> Update(TEntity entity)
    {
        var obj = DbContext.Update(entity);

        await DbContext.SaveChangesAsync();

        return obj.Entity;
    }

    public virtual async Task Delete(TEntity entity)
    {
        DbContext.Remove(entity);

        await DbContext.SaveChangesAsync();
    }
}
