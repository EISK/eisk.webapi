using Eisk.DataServices.IntegrationTests;

namespace Eisk.DataServices.EntityFrameworkCore.IntegrationTests
{
    public class EmployeeDataServiceTests: EmployeeDataServiceBaseIntegrationTests
    {
        public EmployeeDataServiceTests():base (new EmployeeDataService(new TestDbContextFactory().CreateDbContext()))
        {

        }

    }
}
