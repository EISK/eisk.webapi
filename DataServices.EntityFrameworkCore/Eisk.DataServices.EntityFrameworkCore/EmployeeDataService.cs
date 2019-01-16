using Core.DataService;
using Eisk.DataServices.EntityFrameworkCore.DataContext;
using Eisk.Domains.Employee;
using System.Collections.Generic;
using System.Linq;
using Eisk.DataServices.Interfaces;

namespace Eisk.DataServices.EntityFrameworkCore
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