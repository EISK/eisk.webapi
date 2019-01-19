using Eisk.DataServices.EntityFrameworkCore;
using Eisk.Domains.Employee;
using Eisk.EntityFrameworkCore.Setup;
using Eisk.Test.Core.TestBases;

namespace Eisk.DomainServices.IntegrationTests.EntityFrameworkCore
{
    public class EmployeeDomainServiceIntegrationTests:DomainServiceBaseIntegrationTests<Employee, int>
    {
        public EmployeeDomainServiceIntegrationTests() :
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
