using System;

namespace Test.Core.TestBases
{
    public interface IEntityTest<out TEntity>
    {
        TEntity Factory_Entity(Action<TEntity> action = null);
    }
}
