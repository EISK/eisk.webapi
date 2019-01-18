using System.Linq;
using Eisk.Domains.Employee;
using Eisk.Test.Core.TestBases;
using Xunit;

namespace Eisk.DomainServices.BaseIntegrationTests
{
    public abstract class EmployeeDomainServiceBaseIntegrationTests : DomainServiceBaseIntegrationTests<Employee, int>
    {
    
        protected EmployeeDomainServiceBaseIntegrationTests(EmployeeDomainService employeeDomainService) : 
        base(employeeDomainService, x => x.Id)
        {
            _employeeDomainService = employeeDomainService;
        }

        private readonly EmployeeDomainService _employeeDomainService;

    
        [Fact]
        public void GetByFirstName_ValidFirstNamePassed_ShouldBeFoundInQuery()
        {
            //Arrange
            var firstName = "John";
            var objectToAdd = Factory_Entity(x => x.FirstName = firstName);
            _employeeDomainService.Add(objectToAdd);

            //Act
            var returnEmployee = _employeeDomainService.GetByFirstName(firstName);

            //Assert
            Assert.NotNull(returnEmployee);
            Assert.Equal(firstName, returnEmployee.FirstOrDefault().FirstName);
        }
    }
}
