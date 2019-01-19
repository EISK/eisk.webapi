using Eisk.DataServices.EntityFrameworkCore;
using Eisk.DomainServices.BaseIntegrationTests;
using Eisk.EntityFrameworkCore.Setup;

namespace Eisk.DomainServices.IntegrationTests.EntityFrameworkCore.Ext
{
    public class EmployeeDomainServiceIntegrationTests : EmployeeDomainServiceBaseIntegrationTests
    {
        public EmployeeDomainServiceIntegrationTests() :
            base(new EmployeeDomainService(Factory_DataService()))
        {
            
        }

        static EmployeeDataService Factory_DataService()
        {
            EmployeeDataService employeeDataService = new EmployeeDataService(TestDbContextFactory.CreateDbContext());

            return employeeDataService;
        }
    }
}
