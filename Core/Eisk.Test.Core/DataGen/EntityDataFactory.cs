using System;
using AutoFixture;
using AutoFixture.DataAnnotations;

namespace Eisk.Test.Core.DataGen
{
    public class EntityDataFactory<TEntity>
    {
        public static TEntity Factory_Entity_Instance(Action<TEntity> action = null, Action<Fixture> fixtureAction = null)
        {
            return new EntityDataFactory<TEntity>().Factory_Entity(action, fixtureAction);
        }

        public virtual TEntity Factory_Entity(Action<TEntity> action = null, Action<Fixture> fixtureAction = null)
        {
            var fixture = Factory_Fixture();

            fixtureAction?.Invoke(fixture);

            var obj = Factory_Entity(fixture);

            action?.Invoke(obj);

            return obj;
        }

        public TEntity Factory_Entity(Fixture fixture)
        {
            return fixture.Create<TEntity>();
        }

        public Fixture Factory_Fixture()
        {
            Fixture fixture = new Fixture();

            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());

            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            fixture.Customize(new NoDataAnnotationsCustomization());

            fixture.Customizations.Add(new RangeAttributeRelay());

            //fixture.Customizations.Add(new StringAttributeAggregatedRelay());

            return fixture;
        }
    }
}
