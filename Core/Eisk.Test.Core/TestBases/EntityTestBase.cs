using System;
using System.Linq.Expressions;
using Eisk.Core.Utils;

namespace Eisk.Test.Core.TestBases
{
    public abstract class EntityTestBase<TEntity, TId> : TestBase
        where TEntity : class, new()
    {
        protected readonly Expression<Func<TEntity, TId>> DbIdExpression;
        
        protected EntityTestBase(Expression<Func<TEntity, TId>> idExpression)
        {
            DbIdExpression = idExpression;
        }

        protected virtual TEntity Factory_Entity(Action<TEntity> action = null, bool setIdWithDefault = true)
        {
            var entity = Factory_Entity<TEntity>();

            if (setIdWithDefault)
                SetIdValueToEntity(entity, default(TId));

            action?.Invoke(entity);
            
            return entity;
        }

        protected TId GetIdValueFromEntity(TEntity entity)
        {
            return (TId)ExpressionUtil<TEntity>.GetPropertyValue(DbIdExpression, entity);
        }

        protected void SetIdValueToEntity(TEntity entity, object value)
        {
            ExpressionUtil<TEntity>.SetPropertyValue(DbIdExpression, entity, value);
        }
    }
}
