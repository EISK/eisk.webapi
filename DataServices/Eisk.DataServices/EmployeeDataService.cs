using Core.DataService;
using Eisk.DataServices.DataContext;
using Eisk.Domains.Employee;
using System.Collections.Generic;
using System.Linq;

namespace Eisk.DataServices
{
    public class EmployeeDataService : EntityContextDataService<Employee>
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