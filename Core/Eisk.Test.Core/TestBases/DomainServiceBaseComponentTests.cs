using Eisk.Core.DomainService;
using Eisk.Core.Exceptions;
using Eisk.Test.Core.DataGen.DataFactories;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace Eisk.Test.Core.TestBases;

public abstract class DomainServiceBaseComponentTests<TEntity, TId> : EntityTestBase<TEntity, TId>,
    IServiceTest<DomainService<TEntity, TId>>
    where TEntity : class, new()
{
    private readonly DomainService<TEntity, TId> _domainService;

    protected DomainServiceBaseComponentTests(DomainService<TEntity, TId> domainService,
        Expression<Func<TEntity, TId>> idExpression, EntityDataFactory<TEntity> entityDataFactory) : base(idExpression, entityDataFactory)
    {
        _domainService = domainService;
    }

    public virtual DomainService<TEntity, TId> GetServiceInstance(Action action = null)
    {
        action?.Invoke();

        return _domainService;
    }

    protected virtual async Task CreateTestEntityToStore(TEntity testEntity)
    {
        await _domainService.Add(testEntity);
    }

    [Fact]
    public virtual async Task Add_ValidDomainPassed_ShouldReturnDomainAfterCreation()
    {
        //Arrange
        var inputEntity = Factory_Entity();
        var domainService = GetServiceInstance();

        //Act
        var returnedEntity = await domainService.Add(inputEntity);

        //Assert
        Assert.NotNull(returnedEntity);
        Assert.NotEqual(default(TId), GetIdValueFromEntity(returnedEntity));
    }

    [Fact]
    public virtual async Task Add_NullDomainPassed_ShouldThrowArgumentNullException()
    {
        //Arrange
        var domainService = GetServiceInstance();
        TEntity invalidNullDomain = null;

        //Act and Assert
        await Assert.ThrowsAsync<NullInputEntityException<TEntity>>(() => domainService.Add(invalidNullDomain));

    }

    [Fact]
    public virtual async Task GetById_ValidIdPassed_ShouldReturnResult()
    {
        //Arrange
        var domain = Factory_Entity();
        var domainService = GetServiceInstance(async () =>
        {
            await CreateTestEntityToStore(domain);
        });

        var idValue = GetIdValueFromEntity(domain);

        //Act
        var returnedEntity = await domainService.GetById(idValue);

        //Assert
        Assert.NotNull(returnedEntity);
        Assert.Equal(idValue, GetIdValueFromEntity(returnedEntity));
    }

    [Fact]
    public virtual async Task GetById_EmptyIdPassed_ShouldThrowException()
    {
        //Arrange
        var domainService = GetServiceInstance();
        var emptyIdValue = default(TId);

        //Act + Assert
        await Assert.ThrowsAsync<InvalidLookupIdParameterException<TEntity>>(() => domainService.GetById(emptyIdValue));

    }

    [Fact]
    public virtual async Task Update_ValidDomainPassed_ShouldReturnDomain()
    {
        //Arrange
        var inputEntity = Factory_Entity();
        var domainService = GetServiceInstance(async () =>
        {
            await CreateTestEntityToStore(inputEntity);
        });
        var idValue = GetIdValueFromEntity(inputEntity);

        //Act
        var returnedEntity = await domainService.Update(idValue, inputEntity);

        //Assert
        Assert.NotNull(returnedEntity);
        Assert.Equal(GetIdValueFromEntity(inputEntity), GetIdValueFromEntity(returnedEntity));

    }

    [Fact]
    public virtual async Task Update_EmptyIdPassed_ShouldThrowException()
    {
        //Arrange
        var domainService = GetServiceInstance();
        var emptyIdValue = default(TId);
        TEntity dummayObject = Factory_Entity();

        //Act + Assert
        await Assert.ThrowsAsync<InvalidLookupIdParameterException<TEntity>>(() => domainService.Update(emptyIdValue, dummayObject));

    }

    [Fact]
    public virtual async Task Delete_DomainWithValidIdPassed_ShouldDeleteSuccessfully()
    {
        //Arrange
        var inputEntity = Factory_Entity();
        var domainService = GetServiceInstance(async () => await CreateTestEntityToStore(inputEntity));
        var idValue = GetIdValueFromEntity(inputEntity);

        //Act + Assert
        await domainService.Delete(idValue);

    }

    [Fact]
    public virtual async Task Delete_DomainWithEmptyIdPassed_ShouldThrowException()
    {
        //Arrange
        var domainService = GetServiceInstance();
        var emptyIdValue = default(TId);

        //Act + Assert
        await Assert.ThrowsAsync<InvalidLookupIdParameterException<TEntity>>(() => domainService.Delete(emptyIdValue));

    }
}
