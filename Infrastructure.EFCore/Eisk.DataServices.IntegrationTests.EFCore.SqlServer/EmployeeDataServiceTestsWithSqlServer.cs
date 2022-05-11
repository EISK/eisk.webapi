using Eisk.DataServices.EFCore;
using Eisk.Domains.Entities;
using Eisk.Domains.TestData;
using Eisk.EFCore.Setup;
using Eisk.Test.Core.TestBases;
using Xunit;

namespace Eisk.DataServices.IntegrationTests.EFCore.SqlServer;


public class EmployeeDataServiceTestsWithSqlServer : DataServiceSqlServerBaseIntegrationTests<Employee, int>, IClassFixture<DatabaseSetup>
{
    public EmployeeDataServiceTestsWithSqlServer() : base(new EmployeeDataService(TestDbContextFactory.CreateSqlServerDbContext()), x => x.Id, new EmployeeDataFactory())
    {

    }

}
