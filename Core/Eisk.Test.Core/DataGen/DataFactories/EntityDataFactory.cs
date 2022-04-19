using System;
using AutoFixture;
using AutoFixture.DataAnnotations;

namespace Eisk.Test.Core.DataGen.DataFactories;

public class EntityDataFactory<TEntity>
{
    public virtual TEntity Factory_Entity(Action<TEntity> action = null)
    {
        var fixture = Factory_Fixture();

        var obj = fixture.Create<TEntity>();

        action?.Invoke(obj);

        return obj;
    }

    private Fixture Factory_Fixture()
    {
        Fixture fixture = new Fixture();

        fixture.Behaviors.Remove(new ThrowingRecursionBehavior());

        fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        fixture.Customize(new NoDataAnnotationsCustomization());

        fixture.Customizations.Add(new RangeAttributeRelay());

        fixture.Customizations.Add(new StringAttributeAggregatedRelay());

        return fixture;
    }
}
