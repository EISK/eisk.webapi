using System;

namespace Eisk.Test.Core.DataGen.DataFactories;

public abstract class EntityDomainDataFactory<TEntity> : EntityDataFactory<TEntity>
{
    public override TEntity Factory_Entity(Action<TEntity> action = null)
    {
        var entity = base.Factory_Entity(e =>
        {
            AssignDomainData(e);

            //supporting custom overrides from user
            action?.Invoke(e);
        });

        return entity;
    }

    protected abstract void AssignDomainData(TEntity e);
}
