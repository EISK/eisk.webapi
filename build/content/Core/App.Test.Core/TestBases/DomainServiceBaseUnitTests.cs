using System;
using System.Linq.Expressions;
using Core.DataService;
using Core.DomainService;
using Moq;

namespace Test.Core.TestBases
{
    public abstract class DomainServiceBaseUnitTests<TEntity, TId> : DomainServiceBaseTests<TEntity, TId>
        where TEntity : class, new()
    {
        readonly Mock<IEntityDataService<TEntity>> _dataServiceMock = 
            new Mock<IEntityDataService<TEntity>>();
        
        protected DomainServiceBaseUnitTests(Expression<Func<TEntity, TId>> idExpression):
            base(idExpression)
        {
            
        }

        public override DomainService<TEntity, TId> Factory_Service(Action action = null)
        {
            action?.Invoke();

            return new DomainService<TEntity, TId>(_dataServiceMock.Object);
        }

        #region Test data setups

        protected override TEntity Factory_EntityWithId(Action<TEntity> action = null)
        {
            return Factory_Entity(action);
        }

        protected override void SetIdAndSetupGetById(TEntity getEntity)
        {
            _dataServiceMock.Setup(x => x
                    .GetById(GetIdValueFromEntity(getEntity)))
                .Returns(getEntity);
        }

        protected override void SetupGetThatReturnsNullForId(TId id)
        {
            _dataServiceMock.Setup(x => x
                    .GetById(id))
                .Returns((TEntity) null);
        }

        protected override void SetupAdd(TEntity entityToAdd)
        {
            _dataServiceMock.Setup(x => x.Add(entityToAdd)).Returns(entityToAdd);
        }

        protected override void SetupUpdate(TEntity entityToUpdate)
        {
            _dataServiceMock.Setup(x => x.Update(entityToUpdate)).Returns(entityToUpdate);
        }

        #endregion

    }
}
