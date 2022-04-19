using System;
using System.Linq.Expressions;
using Eisk.Core.Utils;
using Eisk.Test.Core.DataGen.DataFactories;

namespace Eisk.Test.Core.TestBases;

public abstract class EntityTestBase<TEntity, TId> : TestBase
    where TEntity : class, new()
{
    protected readonly Expression<Func<TEntity, TId>> DbIdExpression;
    
    EntityDataFactory<TEntity> _entityDataFactory;
    protected EntityDataFactory<TEntity> EntityDataFactory
    {
        get
        {
            if (_entityDataFactory == null) 
                _entityDataFactory = new EntityDataFactory<TEntity>();

            return _entityDataFactory; ;
        }
    }

    protected const int RANDOM_ID = 10000;
    protected EntityTestBase(Expression<Func<TEntity, TId>> idExpression, EntityDataFactory<TEntity> entityDataFactory = null)
    {
        DbIdExpression = idExpression;
        _entityDataFactory = entityDataFactory;
    }

    protected virtual TEntity Factory_Entity(Action<TEntity> action = null, bool setIdWithDefault = true)
    {
        var entity = EntityDataFactory.Factory_Entity(action);

        if (setIdWithDefault)
            SetIdValueToEntity(entity, default(TId));

        action?.Invoke(entity);

        return entity;
    }

    protected virtual TEntity Factory_EntityWithRandomId(Action<TEntity> action = null)
    {
        var entity = Factory_Entity(action, false);

        SetIdValueToEntity(entity, RANDOM_ID);//TODO: to be randomize

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
