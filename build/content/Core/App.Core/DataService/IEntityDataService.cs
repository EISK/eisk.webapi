using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.DataService
{
    public interface IEntityDataService<TEntity> where TEntity : class, new()
    {
        TEntity GetById<TId>(TId id);
        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> criteria);
        IList<TEntity> GetMultiple(Expression<Func<TEntity, bool>> criteria);
        IList<TEntity> GetAll();
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
    }
}