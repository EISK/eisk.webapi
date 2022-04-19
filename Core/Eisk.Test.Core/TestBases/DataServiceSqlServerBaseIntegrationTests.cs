using Eisk.Core.DataService;
using Eisk.Test.Core.DataGen.DataFactories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace Eisk.Test.Core.TestBases;

public abstract class DataServiceSqlServerBaseIntegrationTests<TEntity, TId> : DataServiceBaseIntegrationTests<TEntity, TId>,
    IServiceTest<IEntityDataService<TEntity>>
    where TEntity : class, new()
{
    protected DataServiceSqlServerBaseIntegrationTests(IEntityDataService<TEntity> dataService, Expression<Func<TEntity, TId>> idExpression, EntityDataFactory<TEntity> entityDataFactory = null)
        :base(dataService, idExpression, entityDataFactory)
    {
        
    }


    [Fact]
    public virtual async Task Add_ValidDomainWithRandomIdPassed_ShouldThrowException()
    {
        //Arrange
        var inputEntityWithRandomId = Factory_EntityWithRandomId();
        var dataService = GetServiceInstance();

        //Assert
        await Assert.ThrowsAsync<DbUpdateException>(() => dataService.Add(inputEntityWithRandomId));
    }
}
