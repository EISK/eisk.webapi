using Eisk.Domains.Employee;
using Test.Core.TestBases;
using Xunit;

namespace Eisk.DataServices.EntityFrameworkCore.IntegrationTests
{
    public class EmployeeDataServiceTests: DataServiceBaseIntegrationTests<Employee, int>
    {
        public EmployeeDataServiceTests():base (new EmployeeDataService(new TestDbContextFactory().CreateDbContext()),
            x => x.Id)
        {

        }

    }
}
