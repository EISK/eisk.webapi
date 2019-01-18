using Eisk.DataServices.EntityFrameworkCore;
using Eisk.DomainServices.BaseIntegrationTests;
using Eisk.EntityFrameworkCore.Setup;

namespace Eisk.DomainServices.IntegrationTests.EntityFrameworkCore.Extended
{
    public class EmployeeDomainServiceIntegrationTests : EmployeeDomainServiceBaseIntegrationTests
    {
        public EmployeeDomainServiceIntegrationTests() :
            base(new EmployeeDomainService(Factory_DataService()))
        {
            
        }

        static EmployeeDataService Factory_DataService()
        {
            var testDb = new InMemoryDbContextFactory();

            EmployeeDataService employeeDataService = new EmployeeDataService(testDb.CreateDbContext());

            return employeeDataService;
        }
    }
}
