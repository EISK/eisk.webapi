namespace Eisk.DataServices.EFCore.IntegrationTests.Ext
{
    using Eisk.EFCore.Setup;

    public class EmployeeDataServiceTests: EmployeeDataServiceBaseIntegrationTests
    {
        public EmployeeDataServiceTests():base (new EmployeeDataService(TestDbContextFactory.CreateDbContext()))
        {

        }

    }
}
