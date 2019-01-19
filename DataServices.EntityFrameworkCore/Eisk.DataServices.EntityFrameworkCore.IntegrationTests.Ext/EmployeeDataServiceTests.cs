using Eisk.DataServices.BaseIntegrationTests;
using Eisk.EntityFrameworkCore.Setup;

namespace Eisk.DataServices.EntityFrameworkCore.IntegrationTests.Ext
{
    public class EmployeeDataServiceTests: EmployeeDataServiceBaseIntegrationTests
    {
        public EmployeeDataServiceTests():base (new EmployeeDataService(new InMemoryDbContextFactory().CreateDbContext()))
        {

        }

    }
}
