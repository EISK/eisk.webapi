using Eisk.Domains.Employee;
using Eisk.EFCore.Setup;
using Eisk.Test.Core.TestBases;

namespace Eisk.DataServices.EFCore.IntegrationTests
{
    public class EmployeeDataServiceTests: DataServiceBaseIntegrationTests<Employee, int>
    {
        public EmployeeDataServiceTests():base (new EmployeeDataService(TestDbContextFactory.CreateDbContext()), x => x.Id)
        {

        }

    }
}
