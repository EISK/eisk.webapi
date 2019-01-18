using Eisk.DataServices.BaseIntegrationTests;
using Eisk.EntityFrameworkCore.Setup;

namespace Eisk.DataServices.EntityFrameworkCore.IntegrationTests.Extended
{
    public class EmployeeDataServiceTests: EmployeeDataServiceBaseIntegrationTests
    {
        public EmployeeDataServiceTests():base (new EmployeeDataService(new InMemoryDbContextFactory().CreateDbContext()))
        {

        }

    }
}
