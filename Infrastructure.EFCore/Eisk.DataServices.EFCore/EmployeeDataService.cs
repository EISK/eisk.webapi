using Eisk.Core.DataService.EFCore;
using Eisk.DataServices.EFCore.DataContext;
using Eisk.DataServices.Interfaces;
using Eisk.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eisk.DataServices.EFCore;


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
