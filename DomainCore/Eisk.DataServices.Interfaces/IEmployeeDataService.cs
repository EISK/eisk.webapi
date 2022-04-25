using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eisk.DataServices.Interfaces;

using Core.DataService;
using Domains.Entities;

public interface IEmployeeDataService : IEntityDataService<Employee>
{
    Task<IList<Employee>> GetByFirstName(string firstName);

}
