using Eisk.Core.Exceptions;
using Eisk.DataServices.Interfaces;
using Eisk.Domains.Employee;
using Moq;
using Xunit;

namespace Eisk.DomainServices.UnitTests
{
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
