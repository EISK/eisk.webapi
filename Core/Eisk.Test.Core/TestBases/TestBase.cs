using System;
using Xunit;

namespace Eisk.Test.Core.TestBases
{
    using DataGen;
    using Eisk.Core.Exceptions;
    
    public abstract class TestBase
    {
        protected static void ExpectException<TException>(Action action, 
            TException expectedException)
            where TException: CoreException
        {
            //Act
            var actualException = Assert.Throws<TException>(action);

            //Assert
            Assert.NotNull(actualException);
            Assert.Equal(expectedException.Message, actualException.Message);
            Assert.Equal(expectedException.ErrorCode, actualException.ErrorCode);
        }

        protected TEntity Factory_Entity<TEntity>(Action<TEntity> action = null)
        {
            return EntityDataFactory<TEntity>.Factory_Entity_Instance(action);
        }
    }
}
