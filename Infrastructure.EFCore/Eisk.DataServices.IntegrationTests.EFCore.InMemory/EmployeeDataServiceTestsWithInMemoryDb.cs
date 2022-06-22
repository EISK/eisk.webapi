using Eisk.DataServices.EFCore;
using Eisk.Domains.Entities;
using Eisk.EFCore.Setup;
using Eisk.Test.Core.TestBases;

namespace Eisk.DataServices.IntegrationTests.EFCore.InMemory;

public class EmployeeDataServiceTestsWithInMemoryDb : DataServiceBaseIntegrationTests<Employee, int>
{
    public EmployeeDataServiceTestsWithInMemoryDb() : base(new EmployeeDataService(TestDbContextFactory.CreateInMemoryDbContext()), x => x.Id)
    {

    }

}
