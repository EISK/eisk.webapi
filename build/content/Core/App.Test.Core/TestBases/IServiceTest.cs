using System;

namespace Test.Core.TestBases
{
    public interface IServiceTest<out T>
    {
        T Factory_Service(Action action = null);
    }
}
