using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eisk.Core.DataService.EFCore;
using Microsoft.EntityFrameworkCore;

namespace Eisk.DataServices.EFCore
{
    using DataContext;
    using Interfaces;
    using Domains.Entities;

    public class EmployeeDataService : EntityDataService<Employee>, IEmployeeDataService
    {
        public EmployeeDataService(AppDbContext dbContext) : base(dbContext)
        {

        }

        public virtual async Task<IList<Employee>> GetByFirstName(string firstName)
        {
            return await DbContext.Set<Employee>().Where(x => x.FirstName.Contains(firstName)).ToListAsync();
        }

    }
}