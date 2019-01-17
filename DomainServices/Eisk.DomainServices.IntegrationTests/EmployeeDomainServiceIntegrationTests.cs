using System;
using System.Linq;
using Eisk.DataServices.EntityFrameworkCore;
using Eisk.Domains.Employee;
using Eisk.DomainServices.IntegrationTests;
using Services.DomainServices;
using Test.Core.TestBases;
using Xunit;

namespace IntegrationTests.DomainServiceTests
{
    public class EmployeeDomainServiceIntegrationTests : DomainServiceBaseIntegrationTests<Employee, int>
    {
        #region Helpers

        public EmployeeDomainServiceIntegrationTests() :
            this(new EmployeeDomainService(Factory_DataService()))
        {
        }

        EmployeeDomainServiceIntegrationTests(EmployeeDomainService employeeDomainService) :
            base(employeeDomainService, x => x.Id)
        {
            _employeeDomainService = employeeDomainService;
        }

        private readonly EmployeeDomainService _employeeDomainService;

        static EmployeeDataService Factory_DataService()
        {
            var testDb = new TestDbContextFactory();

            EmployeeDataService employeeDataService = new EmployeeDataService(testDb.CreateDbContext());

            return employeeDataService;
        }

        #endregion

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
