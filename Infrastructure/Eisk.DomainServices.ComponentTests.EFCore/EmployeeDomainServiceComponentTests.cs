using Eisk.DataServices.EFCore;
using Eisk.Domains.Entities;
using Eisk.EFCore.Setup;
using Eisk.Test.Core.TestBases;

namespace Eisk.DomainServices.ComponentTests.EFCore
{
    public class EmployeeDomainServiceComponentTests : DomainServiceBaseComponentTests<Employee, int>
    {
        public EmployeeDomainServiceComponentTests() :
            base(new EmployeeDomainService(Factory_DataService()), x => x.Id)
        {
            
        }

        static EmployeeDataService Factory_DataService()
        {
            EmployeeDataService employeeDataService = new EmployeeDataService(TestDbContextFactory.CreateDbContext());

            return employeeDataService;
        }
    }
}
