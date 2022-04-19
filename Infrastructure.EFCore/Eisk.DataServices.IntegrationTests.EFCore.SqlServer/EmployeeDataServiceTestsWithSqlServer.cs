using Xunit;

namespace Eisk.DataServices.IntegrationTests.EFCore.SqlServer;

using Domains.Entities;
using Test.Core.TestBases;
using Domains.TestData;
using Eisk.EFCore.Setup;
using Eisk.DataServices.EFCore;

public class EmployeeDataServiceTestsWithSqlServer: DataServiceSqlServerBaseIntegrationTests<Employee, int>, IClassFixture<DatabaseSetup>
{
    public EmployeeDataServiceTestsWithSqlServer(): base(new EmployeeDataService(TestDbContextFactory.CreateSqlServerDbContext()), x => x.Id, new EmployeeDataFactory())
    {
        
    }

}
