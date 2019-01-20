using Eisk.DataServices.BaseIntegrationTests;
using Eisk.EFCore.Setup;

namespace Eisk.DataServices.EFCore.IntegrationTests.Ext
{
    public class EmployeeDataServiceTests: EmployeeDataServiceBaseIntegrationTests
    {
        public EmployeeDataServiceTests():base (new EmployeeDataService(TestDbContextFactory.CreateDbContext()))
        {

        }

    }
}
