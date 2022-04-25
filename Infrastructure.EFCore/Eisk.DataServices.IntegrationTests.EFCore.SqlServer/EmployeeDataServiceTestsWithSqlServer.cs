using Xunit;

namespace Eisk.DataServices.IntegrationTests.EFCore.SqlServer;

using Domains.Entities;
using Domains.TestData;
using Eisk.DataServices.EFCore;
using Eisk.EFCore.Setup;
using Test.Core.TestBases;

public class EmployeeDataServiceTestsWithSqlServer : DataServiceSqlServerBaseIntegrationTests<Employee, int>, IClassFixture<DatabaseSetup>
{
    public EmployeeDataServiceTestsWithSqlServer() : base(new EmployeeDataService(TestDbContextFactory.CreateSqlServerDbContext()), x => x.Id, new EmployeeDataFactory())
    {

    }

}
