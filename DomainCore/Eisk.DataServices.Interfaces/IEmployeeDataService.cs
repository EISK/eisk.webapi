using Eisk.Domains.Employee;
using System.Collections.Generic;
using Eisk.Core.DataService;

namespace Eisk.DataServices.Interfaces
{
    public interface IEmployeeDataService: IEntityDataService<Employee>
    {
        IList<Employee> GetByFirstName(string firstName);

    }
}