using Eisk.DataServices.EFCore;
using Eisk.DomainServices.BaseIntegrationTests;
using Eisk.EFCore.Setup;

namespace Eisk.DomainServices.IntegrationTests.EFCore.Ext
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
