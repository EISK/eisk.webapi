using System;

namespace Test.Core.TestBases
{
    public abstract class EntityTestBase<TEntity>: TestBase, IEntityTest<TEntity>
    {
        public virtual TEntity Factory_Entity(Action<TEntity> action = null)
        {
            return Factory_Entity<TEntity>(action);
        }
    }
}
