using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Eisk.Core.Exceptions;

namespace Eisk.Core.DomainService
{
    using DataService;
    using Utils;

    public class DomainService<TDomain, TId>
        where TDomain : class, new()
    {
        readonly IEntityDataService<TDomain> _entityDataService;

        public DomainService(IEntityDataService<TDomain> entityDataService)
        {
            _entityDataService = entityDataService;
        }

        public virtual async Task<IEnumerable<TDomain>> GetAll()
        {
            return await _entityDataService.GetAll();
        }

        public virtual async Task<TDomain> GetById(TId id)
        {
            if (id.IsNullOrEmpty())
                ThrowExceptionForInvalidLookupIdParameter();

            var entityInDb = await _entityDataService.GetById(id);

            if (entityInDb == null)
                ThrowExceptionForNonExistantEntity(id);

            return entityInDb;
        }

        public virtual async Task<TDomain> Add(TDomain entity)
        {
            return await Add(entity, null);
        }

        public virtual async Task<TDomain> Add(TDomain entity, Action<TDomain> preProcessAction, Action<TDomain> postProcessAction = null)
        {
            if (entity == null)
                ThrowExceptionForNullInputEntity();

            preProcessAction?.Invoke(entity);

            var returnVal = await _entityDataService.Add(entity);

            postProcessAction?.Invoke(returnVal);

            return returnVal;
        }

        public virtual async Task<TDomain> Update(TId id, TDomain newEntity)
        {
            return await Update(id, newEntity, null);
        }

        public virtual async Task<TDomain> Update(TId id, TDomain newEntity, Action<TDomain, TDomain> preProcessAction, Action<TDomain> postProcessAction = null)
        {
            if (id.IsNullOrEmpty())
                ThrowExceptionForInvalidLookupIdParameter();

            if (newEntity == null)
                ThrowExceptionForNullInputEntity();

            var oldEntity = await GetById(id);

            preProcessAction?.Invoke(oldEntity, newEntity);

            var returnVal = await _entityDataService.Update(newEntity);

            postProcessAction?.Invoke(returnVal);

            return returnVal;
        }

        public virtual async Task Delete(TId id)
        {
            var entityInDb = await GetById(id);

            await _entityDataService.Delete(entityInDb);
        }

        protected virtual void ThrowExceptionForNullInputEntity()
        {
            throw new NullInputEntityException<TDomain>();
        }

        protected virtual void ThrowExceptionForInvalidLookupIdParameter()
        {
            throw new InvalidLookupIdParameterException<TDomain>();
        }

        protected virtual void ThrowExceptionForNonExistantEntity(TId idValue)
        {
            throw new NonExistantEntityException<TDomain>(idValue);
        }
    }
}