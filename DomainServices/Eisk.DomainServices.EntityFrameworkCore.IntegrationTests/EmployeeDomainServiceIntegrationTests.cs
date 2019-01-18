using Eisk.DataServices.EntityFrameworkCore;
using Eisk.DomainServices.IntegrationTests;
using Services.DomainServices;

namespace Eisk.DomainServices.EntityFrameworkCore.IntegrationTests
{
    public class EmployeeDomainServiceIntegrationTests : EmployeeDomainServiceBaseIntegrationTests
    {
        public EmployeeDomainServiceIntegrationTests() :
            base(new EmployeeDomainService(Factory_DataService()))
        {
            
        }

        static EmployeeDataService Factory_DataService()
        {
            var testDb = new TestDbContextFactory();

            EmployeeDataService employeeDataService = new EmployeeDataService(testDb.CreateDbContext());

            return employeeDataService;
        }
    }
}
