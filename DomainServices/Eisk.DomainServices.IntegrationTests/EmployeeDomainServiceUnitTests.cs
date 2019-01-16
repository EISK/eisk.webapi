using Core.Exceptions;
using Eisk.DataServices.Interfaces;
using Moq;
using Services.DomainServices;
using Xunit;

namespace UnitTests.DomainServiceTests
{
    public class EmployeeDomainServiceUnitTests
    {
        #region Helpers

        public EmployeeDomainServiceUnitTests()
        {

        }

        static Mock<IEmployeeDataService> Factory_DataService()
        {
            Mock<IEmployeeDataService> employeeDataServiceMock = new Mock<IEmployeeDataService>();

            return employeeDataServiceMock;
        }

        static EmployeeDomainService Factory_DomainService()
        {
            return new EmployeeDomainService(Factory_DataService().Object) ;
        }

        #endregion

        [Fact]
        public void Add_NullEmployeePassed_ShouldThrowException()
        {
            //Act + Assert
            var error = Assert.Throws<NullInputEntityException>(testCode: () => Factory_DomainService().Add(null));

            //Assert
            Assert.Equal("Input object to be created or updated is null.", error.Message);

        }
    }
}
