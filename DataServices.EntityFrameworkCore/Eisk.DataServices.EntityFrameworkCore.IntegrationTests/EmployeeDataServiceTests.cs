using Eisk.DataServices.IntegrationTests;
using Eisk.DomainServices.IntegrationTests;

namespace Eisk.DataServices.EntityFrameworkCore.IntegrationTests
{
    public class EmployeeDataServiceTests: EmployeeDataServiceBaseIntegrationTests
    {
        public EmployeeDataServiceTests():base (new EmployeeDataService(new InMemoryDbContextFactory().CreateDbContext()))
        {

        }

    }
}
