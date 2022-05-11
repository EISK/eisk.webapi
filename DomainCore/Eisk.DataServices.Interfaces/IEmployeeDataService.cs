using Eisk.Core.DataService;
using Eisk.Domains.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eisk.DataServices.Interfaces;

public interface IEmployeeDataService : IEntityDataService<Employee>
{
    Task<IList<Employee>> GetByFirstName(string firstName);

}
