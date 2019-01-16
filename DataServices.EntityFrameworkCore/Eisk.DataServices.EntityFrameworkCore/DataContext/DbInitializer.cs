using Eisk.Domains.Employee;
using System.Linq;

namespace Eisk.DataServices.EntityFrameworkCore.DataContext
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            //context.Database.EnsureDeleted();

            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Employees.Any())
            {
                return; // DB has been seeded
            }

            for (int i = 0; i < 10; i++)
                context.Employees.Add(new Employee {FirstName = "John"});

            context.SaveChanges();
        }
    }
}