using Eisk.Core.DomainService;
using Eisk.DataServices.Interfaces;
using Eisk.Domains.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eisk.DomainServices;


public class EmployeeDomainService : DomainService<Employee, int>
{
    private readonly IEmployeeDataService _employeeDataService;

    public EmployeeDomainService(IEmployeeDataService employeeDataService) : base(employeeDataService)
    {
        _employeeDataService = employeeDataService;
    }

    public virtual async Task<IList<Employee>> GetByFirstName(string firstName)
    {
        return await _employeeDataService.GetByFirstName(firstName);
    }

}
