using Eisk.DataServices.EFCore;
using Eisk.Domains.Entities;
using Eisk.Domains.TestData;
using Eisk.EFCore.Setup;
using Eisk.Test.Core.TestBases;

namespace Eisk.DomainServices.ComponentTests.EFCore;

public class EmployeeDomainServiceComponentTests : DomainServiceBaseComponentTests<Employee, int>
{
    public EmployeeDomainServiceComponentTests() :
        base(new EmployeeDomainService(Factory_DataService()), x => x.Id, new EmployeeDataFactory())
    {

    }

    static EmployeeDataService Factory_DataService()
    {
        EmployeeDataService employeeDataService = new EmployeeDataService(TestDbContextFactory.CreateInMemoryDbContext());

        return employeeDataService;
    }
}
