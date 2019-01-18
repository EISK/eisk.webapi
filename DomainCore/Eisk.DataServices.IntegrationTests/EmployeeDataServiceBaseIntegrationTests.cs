using Eisk.DataServices.Interfaces;
using Eisk.Domains.Employee;
using Test.Core.TestBases;
using Xunit;

namespace Eisk.DataServices.IntegrationTests
{
    public abstract class EmployeeDataServiceBaseIntegrationTests : DataServiceBaseIntegrationTests<Employee, int>
    {
        protected EmployeeDataServiceBaseIntegrationTests(IEmployeeDataService employeeDataService) :base (employeeDataService, x => x.Id)
        {

        }

    }
}
