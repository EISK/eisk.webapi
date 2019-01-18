using Core.DataService;
using Eisk.Domains.Employee;
using System.Collections.Generic;

namespace Eisk.DataServices.Interfaces
{
    public interface IEmployeeDataService: IEntityDataService<Employee>
    {
        IList<Employee> GetByFirstName(string firstName);

    }
}