using Eisk.Core.DataService;
using Eisk.Test.Core.DataGen;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace Eisk.Test.Core.TestBases
{
    public abstract class DataServiceBaseIntegrationTests<TEntity, TId> : EntityTestBase<TEntity, TId>,
        IServiceTest<IEntityDataService<TEntity>>
        where TEntity : class, new()
    {
        private readonly IEntityDataService<TEntity> _dataService;

        protected DataServiceBaseIntegrationTests(IEntityDataService<TEntity> dataService, Expression<Func<TEntity, TId>> idExpression, EntityDataFactory<TEntity> entityDataFactory = null)
            :base(idExpression, entityDataFactory)
        {
            _dataService = dataService;
        }


        public virtual IEntityDataService<TEntity> GetServiceInstance(Action action = null)
        {
            action?.Invoke();

            return _dataService;
        }

        protected virtual async Task CreateTestEntityToStore(TEntity testEntity)
        {
            await _dataService.Add(testEntity);
        }

        [Fact]
        public virtual async Task Add_ValidDomainPassed_ShouldReturnDomainAfterCreation()
        {
            //Arrange
            var inputEntity = Factory_Entity();
            var dataService = GetServiceInstance();

            //Act
            var returnedEntity = await dataService.Add(inputEntity);

            //Assert
            Assert.NotNull(returnedEntity);
            Assert.NotEqual(default(TId), GetIdValueFromEntity(returnedEntity));
        }

        [Fact]
        public virtual async Task Add_NullDomainPassed_ShouldThrowArgumentNullException()
        {
            //Arrange
            var dataService = GetServiceInstance();
            TEntity invalidNullDomain = null;

            //Act and Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => dataService.Add(invalidNullDomain));

        }

        [Fact]
        public virtual async Task GetById_ValidIdPassed_ShouldReturnResult()
        {
            //Arrange
            var domain = Factory_Entity();
            var dataService = GetServiceInstance();
            await CreateTestEntityToStore(domain);

            var idValue = GetIdValueFromEntity(domain);
            
            //Act
            var returnedEntity = await dataService.GetById(idValue);

            //Assert
            Assert.NotNull(returnedEntity);
            Assert.Equal(idValue, GetIdValueFromEntity(returnedEntity));
        }

        [Fact]
        public virtual async Task GetById_EmptyIdPassed_ShouldReturnNull()
        {
            //Arrange
            var dataService = GetServiceInstance();
            
            //Act
            var returnedEntity = await dataService.GetById(default(TId));

            //Assert
            Assert.Null(returnedEntity);
            
        }

        [Fact]
        public virtual async Task GetById_InvalidIdPassed_ShouldReturnNull()
        {
            //Arrange
            var dataService = GetServiceInstance();

            //Act
            var returnedEntity = await dataService.GetById(RANDOM_ID);//TODO: make it generic random

            //Assert
            Assert.Null(returnedEntity);

        }

        [Fact]
        public virtual async Task Update_ValidDomainPassed_ShouldReturnDomain()
        {
            //Arrange
            var inputEntity = Factory_Entity();
            var dataService = GetServiceInstance();
            await CreateTestEntityToStore(inputEntity);

            //Act
            var returnedEntity = await dataService.Update(inputEntity);

            //Assert
            Assert.NotNull(returnedEntity);
            Assert.Equal(GetIdValueFromEntity(inputEntity), GetIdValueFromEntity(returnedEntity));

        }

        [Fact]
        public virtual async Task Update_ValidDomainWithEmptyIdPassed_ShouldCreateDomain()
        {
            //Arrange
            var inputEntity = Factory_Entity();
            var dataService = GetServiceInstance();

            //Act
            var returnedEntity = await dataService.Update(inputEntity);//may not be supported in all data providers

            //Assert
            Assert.NotNull(returnedEntity);
            Assert.NotEqual(default(TId), GetIdValueFromEntity(returnedEntity));

        }

        [Fact]
        public virtual async Task Update_ValidDomainWithRandomIdPassed_ShouldThrowException()
        {
            //Arrange
            var entityWithRandomId = Factory_EntityWithRandomId();
            
            var dataService = GetServiceInstance();

            //Act
            var ex = await Record.ExceptionAsync(async () => await dataService.Update(entityWithRandomId));

            //Assert
            Assert.NotNull(ex);
        }

        [Fact]
        public virtual async Task Update_NullDomainPassed_ShouldThrowArgumentNullException()
        {
            //Arrange
            var dataService = GetServiceInstance();
            TEntity invalidNullDomain = null;

            //Act and Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => dataService.Update(invalidNullDomain));

        }

        [Fact]
        public virtual async Task Delete_DomainWithValidIdPassed_ShouldDeleteSuccessfully()
        {
            //Arrange
            var inputEntity = Factory_Entity();
            var dataService = GetServiceInstance();
            await CreateTestEntityToStore(inputEntity);
            var idValue = GetIdValueFromEntity(inputEntity);

            //Act
            await dataService.Delete(inputEntity);

            //Assert
            var returnObject = await dataService.GetById(idValue);
            Assert.Null(returnObject);
        }

        [Fact]
        public virtual async Task Delete_DomainWithEmptyIdPassed_ShouldThrowException()
        {
            //Arrange
            var inputEntity = Factory_Entity();
            var dataService = GetServiceInstance();
            
            //Act
            var returnedException = await Record.ExceptionAsync(() => dataService.Delete(inputEntity));

            //Assert
            Assert.NotNull(returnedException);
        }

        [Fact]
        public virtual async Task Delete_DomainWithRandomIdPassed_ShouldThrowException()
        {
            //Arrange
            var inputEntity = Factory_EntityWithRandomId();
            var dataService = GetServiceInstance();
            
            //Act
            var ex = await Record.ExceptionAsync(() => dataService.Delete(inputEntity));

            //Assert
            Assert.NotNull(ex);
        }
    }
}
