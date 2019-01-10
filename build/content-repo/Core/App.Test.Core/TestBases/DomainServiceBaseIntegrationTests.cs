using System;
using System.Linq.Expressions;
using Core.DataService;
using Core.DomainService;

namespace Test.Core.TestBases
{
    public abstract class DomainServiceBaseIntegrationTests<TEntity, TId> : DomainServiceBaseTests<TEntity, TId>
        where TEntity : class, new()
    {
        private readonly IEntityDataService<TEntity> _dataService;

        private readonly DomainService<TEntity, TId> _domainService;

        protected DomainServiceBaseIntegrationTests(Expression<Func<TEntity, TId>> idExpression, 
            DomainService<TEntity, TId> domainService):
            base(idExpression)
        {
            _domainService = domainService;
            _dataService = _domainService.EntityDataService;
        }

        public override DomainService<TEntity, TId> Factory_Service(Action action = null)
        {
            action?.Invoke();

            return _domainService;
        }

        #region Test data setups

        protected override TEntity Factory_EntityWithId(Action<TEntity> action = null)
        {
            return Factory_Entity(action);
        }

        protected override void SetIdAndSetupGetById(TEntity getEntity)
        {
            _dataService.Add(getEntity);
        }

        #endregion

    }
}
