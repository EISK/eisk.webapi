using Eisk.Core.Exceptions;
using Eisk.DataServices.Interfaces;
using Eisk.Domains.Entities;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Eisk.DomainServices.UnitTests;

public class EmployeeDomainServiceUnitTests
{
    #region Helpers

    static Mock<IEmployeeDataService> Factory_DataService()
    {
        Mock<IEmployeeDataService> employeeDataServiceMock = new Mock<IEmployeeDataService>();

        return employeeDataServiceMock;
    }

    static EmployeeDomainService Factory_DomainService()
    {
        return new EmployeeDomainService(Factory_DataService().Object);
    }

    #endregion

    [Fact]
    public async Task Add_NullEmployeePassed_ShouldThrowExceptionAsync()
    {
        //Act + Assert
        var error = await Assert.ThrowsAsync<NullInputEntityException<Employee>>(testCode: () => Factory_DomainService().Add(null));

        //Assert
        Assert.Equal("Input object to be created or updated is null.", error.Message);

    }
}
