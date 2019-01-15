using System;
using Core.Exceptions;
using Test.Core.DataGen;
using Xunit;

namespace Test.Core.TestBases
{
    public abstract class TestBase
    {
        protected static void ExpectException<TException>(Action action, 
            TException expectedIdentityHttpError)
            where TException: CoreException
        {
            //Act
            var actualException = Assert.Throws<TException>(action);

            //Assert
            Assert.NotNull(actualException);
            Assert.Equal(expectedIdentityHttpError.Message, actualException.Message);
            Assert.Equal(expectedIdentityHttpError.ErrorCode, actualException.ErrorCode);
        }

        protected static void ExpectException<TException>(Action action)
            where TException : CoreException, new()
        {
            ExpectException(action, new TException());
        }

        protected void AssertValidationAttribute(Type entityType, string fieldName, Type attributeType)
        {
            var pi = entityType.GetProperty(fieldName);
            var hasIsIdentity = Attribute.IsDefined(pi, attributeType);
            Assert.True(hasIsIdentity);
        }

        protected TEntity Factory_Entity<TEntity>(Action<TEntity> action = null)
        {
            return EntityDataFactory<TEntity>.Create_Entity(action);
        }
    }
}
