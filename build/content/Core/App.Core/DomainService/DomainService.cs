using System;
using System.Collections.Generic;
using Core.DataService;
using Core.Exceptions;
using Core.ExtensionMethods;
using Core.Utils;

namespace Core.DomainService
{
    public class DomainService<TDomain, TId>
        where TDomain : class, new()
    {
        public readonly IEntityDataService<TDomain> EntityDataService;

        public DomainService(IEntityDataService<TDomain> entityDataService)
        {
            EntityDataService = entityDataService;
        }

        public virtual IEnumerable<TDomain> GetAll()
        {
            return EntityDataService.GetAll();
        }

        public virtual TDomain GetById(TId id)
        {
            if (id.IsNullOrEmpty())
                ThrowExceptionForInvalidLookupIdParameter();

            var entityInDb = EntityDataService.GetById(id);

            if (entityInDb == null)
                ThrowExceptionForNonExistantEntity(id);

            return entityInDb;
        }

        public virtual TDomain Add(TDomain entity)
        {
            return Add(entity, null);
        }

        public virtual TDomain Add(TDomain entity, Action<TDomain> preProcessAction, Action<TDomain> postProcessAction = null)
        {
            if (entity == null)
                ThrowExceptionForNullInputEntity();

            preProcessAction?.Invoke(entity);

            var returnVal = EntityDataService.Add(entity);

            postProcessAction?.Invoke(returnVal);

            return returnVal;
        }

        public virtual TDomain Update(TId id, TDomain newEntity)
        {
            return Update(id, newEntity, null);
        }

        public virtual TDomain Update(TId id, TDomain newEntity, Action<TDomain, TDomain> preProcessAction, Action<TDomain> postProcessAction = null)
        {
            if (id.IsNullOrEmpty())
                ThrowExceptionForInvalidLookupIdParameter();

            if (newEntity == null)
                ThrowExceptionForNullInputEntity();

            var oldEntity = GetById(id);

            preProcessAction?.Invoke(oldEntity, newEntity);

            var returnVal = EntityDataService.Update(newEntity);

            postProcessAction?.Invoke(returnVal);

            return returnVal;
        }

        public virtual void Delete(TId id)
        {
            if (id.IsNullOrEmpty())
                ThrowExceptionForInvalidLookupIdParameter();

            var entityInDb = GetById(id);

            EntityDataService.Delete(entityInDb);
        }

        protected virtual void ThrowExceptionForNullInputEntity()
        {
            ExceptionThrower.Throws<NullInputEntityException>();
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