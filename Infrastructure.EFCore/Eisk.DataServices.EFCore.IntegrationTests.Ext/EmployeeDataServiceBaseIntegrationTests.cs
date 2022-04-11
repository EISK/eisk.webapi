using Eisk.DataServices.Interfaces;
using Eisk.Domains.Entities;
using Eisk.Test.Core.TestBases;

namespace Eisk.DataServices.EFCore.IntegrationTests.Ext
{
    public abstract class EmployeeDataServiceBaseIntegrationTests : DataServiceBaseIntegrationTests<Employee, int>
    {
        protected EmployeeDataServiceBaseIntegrationTests(IEmployeeDataService employeeDataService) :base (employeeDataService, x => x.Id)
        {

        }

    }
}
