using System.Collections.Generic;
using Core.DomainService;
using Eisk.DataServices.Interfaces;
using Eisk.Domains.Employee;

namespace Services.DomainServices
{
    public class EmployeeDomainService : DomainService<Employee, int>
    {
        private readonly IEmployeeDataService _employeeDataService;

        public EmployeeDomainService(IEmployeeDataService employeeDataService) : base(employeeDataService)
        {
            _employeeDataService = employeeDataService;
        }

        public virtual IList<Employee> GetByFirstName(string firstName)
        {
            return _employeeDataService.GetByFirstName(firstName);
        }

    }
}