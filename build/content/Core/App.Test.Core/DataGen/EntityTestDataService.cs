using System;
using Core.DataService;
using Microsoft.EntityFrameworkCore;

namespace Test.Core.DataGen
{
    public class EntityTestDataService<TEntity> : EntityContextDataService<TEntity>
        where TEntity : class, new()
    {
        public EntityTestDataService(DbContext dbContext) : base(dbContext)
        {
        }

        public virtual TEntity Add_TestData_InStore(Action<TEntity> action = null)
        {
            var entity = EntityDataFactory<TEntity>.Create_Entity(action);
            return Add(entity);
        }
    }
}
