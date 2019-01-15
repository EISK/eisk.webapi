using System;
using System.Linq.Expressions;
using Core.DomainService;
using Core.Exceptions;
using Core.Utils;
using Xunit;

namespace Test.Core.TestBases
{
    public abstract class DomainServiceBaseTests<TEntity, TId> : EntityTestBase<TEntity>, 
        IServiceTest<DomainService<TEntity, TId>>
        where TEntity : class, new()
    {
        private readonly Expression<Func<TEntity, TId>> _idExpression;

        protected DomainServiceBaseTests(Expression<Func<TEntity, TId>> idExpression)
        {
            _idExpression = idExpression;
        }

        #region Helpers 

        public abstract DomainService<TEntity, TId> Factory_Service(Action action = null);

        protected TId GetIdValueFromEntity(TEntity entity)
        {
            return (TId)ExpressionUtil<TEntity>.GetPropertyValue(_idExpression, entity);
        }

        //private void SetIdValueToEntity(TEntity entity, object value)
        //{
        //    ExpressionUtil<TEntity>.SetPropertyValue(_idExpression, entity, value);
        //}

        //void SetDifferentIdValueToTargetForIntegerId(TEntity referenceEntity, TEntity targetEntity)
        //{
        //    if (typeof(TId) == typeof(int))
        //    {
        //        var referenceValue = Convert.ToInt32(GetIdValueFromEntity(referenceEntity));
        //        SetIdValueToEntity(targetEntity, ++referenceValue);
        //    }
        //}

        #endregion 

        #region Test data setups 

        protected abstract TEntity Factory_EntityWithId(Action<TEntity> action = null);

        protected abstract void SetIdAndSetupGetById(TEntity getEntity);

        protected virtual void SetupGetThatReturnsNullForId(TId id)
        {

        }

        protected virtual void SetupAdd(TEntity entityToAdd)
        {

        }

        protected virtual void SetupUpdate(TEntity entityToUpdate)
        {

        }


        #endregion

        #region Errors

        protected virtual InvalidLookupIdParameterException<TEntity> Factory_Exception_ParameterCanNotBeEmpty()
        {
            return new InvalidLookupIdParameterException<TEntity>();
        }

        protected virtual NonExistantEntityException<TEntity>
            Factory_Exception_EntityDoesNotExistInDbForGivenParameter(TId id)
        {
            return new NonExistantEntityException<TEntity>(id);
        }

        protected virtual UpdatingIdIsNotSupported<TEntity>
            Factory_Exception_UpdatingIdIsNotSupported(TId value)
        {
            return new UpdatingIdIsNotSupported<TEntity>(value);
        }

        #endregion

        [Fact]
        public virtual void GetById_ValidIdPassed_ShouldReturnResult()
        {
            //Arrange
            var domain = Factory_Entity();
            var service = Factory_Service(() => SetIdAndSetupGetById(domain));
            var idValue = GetIdValueFromEntity(domain);
            //Act
            var domainReturned = service.GetById(idValue);

            //Assert
            Assert.NotNull(domainReturned);
            Assert.Equal(idValue, GetIdValueFromEntity(domainReturned));
        }

        [Fact]
        public virtual void GetById_InvalidIdPassed_ShouldThrowExeption()
        {
            //Arrange
            var expectedError = Factory_Exception_ParameterCanNotBeEmpty();

            //Act + Assert
            ExpectException(() => Factory_Service().GetById(default(TId)), expectedError);
        }

        [Fact]
        public virtual void GetById_NonExistIdPassed_ShouldThrowExeption()
        {
            //Arrange
            var testId = GetIdValueFromEntity(Factory_EntityWithId());
            var service = Factory_Service(() => SetupGetThatReturnsNullForId(testId));
            var expectedError = Factory_Exception_EntityDoesNotExistInDbForGivenParameter(testId);

            //Act + Assert
            ExpectException(() => service.GetById(testId), expectedError);
        }

        [Fact]
        public virtual void Add_ValidDomainPassed_ShouldReturnDomainAfterCreation()
        {
            //Arrange
            var domainInput = Factory_Entity();
            var service = Factory_Service(() => SetupAdd(domainInput));

            //Act
            var domainReturned = service.Add(domainInput);

            //Assert
            Assert.NotNull(domainReturned);
            Assert.Equal(GetIdValueFromEntity(domainInput), GetIdValueFromEntity(domainReturned));
        }

        [Fact]
        public virtual void Update_ValidDomainPassed_ShouldReturnDomain()
        {
            //Arrange
            var domainInput = Factory_Entity();
            var service = Factory_Service(() =>
            {
                SetIdAndSetupGetById(domainInput);
                SetupUpdate(domainInput);
            });

            //Act
            var domainReturned = service.Update(GetIdValueFromEntity(domainInput), domainInput);

            //Assert
            Assert.NotNull(domainReturned);
            Assert.Equal(GetIdValueFromEntity(domainInput), GetIdValueFromEntity(domainReturned));

        }

        [Fact]
        public virtual void Update_NonExistIdPassed_ShouldThrowException()
        {
            //Arrange
            var domainInput = Factory_EntityWithId();
            var nonExistEntityId = GetIdValueFromEntity(domainInput);
            var service = Factory_Service(() => SetupGetThatReturnsNullForId(nonExistEntityId));
            var expectedError = Factory_Exception_EntityDoesNotExistInDbForGivenParameter(nonExistEntityId);

            //Act + Assert
            ExpectException(() => service.Update(nonExistEntityId, domainInput), expectedError);
        }

        //[Fact]
        //public virtual void Update_DomainWithNewIdPassed_ShouldThrowException()
        //{
        //    //Arrange
        //    var domainGet = Factory_Entity();
        //    var service = Factory_Service(() => SetIdAndSetupGetById(domainGet));

        //    var domainUpdate = Factory_Entity();
        //    SetDifferentIdValueToTargetForIntegerId(domainGet, domainUpdate);
        //    var expectedError = Factory_Exception_UpdatingIdIsNotSupported(GetIdValueFromEntity(domainUpdate));

        //    //Act + Assert
        //    ExpectException(() => service.Update(GetIdValueFromEntity(domainGet), domainUpdate), expectedError);
        //}

        [Fact]
        public virtual void Delete_ValidDomainIdPassed_ShouldDeleteSuccessfully()
        {
            //Arrange
            var domain = Factory_EntityWithId();
            var service = Factory_Service(() => SetIdAndSetupGetById(domain));

            //Act
            service.Delete(GetIdValueFromEntity(domain));
        }

        [Fact]
        public virtual void Delete_DomainWithNonExistingIdPassed_ShouldThrowException()
        {
            //Arrange
            var testId = GetIdValueFromEntity(Factory_EntityWithId());
            var service = Factory_Service(() => SetupGetThatReturnsNullForId(testId));
            var expectedError = Factory_Exception_EntityDoesNotExistInDbForGivenParameter(testId);

            //Act + Assert
            ExpectException(() => service.Delete(testId), expectedError);
        }
    }
}
