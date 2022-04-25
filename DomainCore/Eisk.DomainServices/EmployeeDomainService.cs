using System.Collections.Generic;
using System.Threading.Tasks;
namespace Eisk.DomainServices;

using Core.DomainService;
using DataServices.Interfaces;
using Domains.Entities;

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
