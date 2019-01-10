using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Core.DataService
{
    public class EntityUnitOfWorkDataService<TEntity> : IEntityDataService<TEntity> where TEntity : class, new()
    {
        protected readonly DbContext DbContext;

        public EntityUnitOfWorkDataService(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual TEntity GetById<TId>(TId id)
        {
            return DbContext.Find<TEntity>(id);
        }

        public virtual TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> criteria)
        {
            return DbContext.Set<TEntity>().FirstOrDefault(criteria);
        }

        public virtual IList<TEntity> GetMultiple(Expression<Func<TEntity, bool>> criteria)
        {
            return DbContext.Set<TEntity>().Where(criteria).ToList();
        }

        public virtual IList<TEntity> GetAll()
        {
            return DbContext.Set<TEntity>().ToList();
        }

        public virtual TEntity Add(TEntity entity)
        {
            var obj = DbContext.Add(entity);

            return obj.Entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            var obj = DbContext.Update(entity);

            return obj.Entity;
        }

        public virtual void Delete(TEntity entity)
        {
            DbContext.Remove(entity);
        }

        public virtual void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}