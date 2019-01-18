using Eisk.DataServices.Interfaces;
using Eisk.Domains.Employee;
using Eisk.Test.Core.TestBases;

namespace Eisk.DataServices.BaseIntegrationTests
{
    public abstract class EmployeeDataServiceBaseIntegrationTests : DataServiceBaseIntegrationTests<Employee, int>
    {
        protected EmployeeDataServiceBaseIntegrationTests(IEmployeeDataService employeeDataService) :base (employeeDataService, x => x.Id)
        {

        }

    }
}
