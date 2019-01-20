using System.Collections.Generic;
using System.Linq;
using Eisk.Core.DataService.EFCore;
using Eisk.DataServices.EFCore.DataContext;
using Eisk.DataServices.Interfaces;
using Eisk.Domains.Employee;

namespace Eisk.DataServices.EFCore
{
    public class EmployeeDataService : EntityContextDataService<Employee>, IEmployeeDataService
    {
        public EmployeeDataService(AppDbContext dbContext) : base(dbContext)
        {

        }

        public virtual IList<Employee> GetByFirstName(string firstName)
        {
            return DbContext.Set<Employee>().Where(x => x.FirstName.Contains(firstName)).ToList();
        }

    }
}