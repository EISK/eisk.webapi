using Eisk.Domains.Employee;
using System.Linq;
using Test.Core.DataGen;

namespace Eisk.DataServices.DataContext
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
                context.Employees.Add(
                    EntityDataFactory<Employee>.Create_Entity(x =>
                    {
                        x.Id = 0;
                        x.ReportsToId = null;
                        x.ReportsTo = null;
                        x.Subordinates = null;
                    })
                );

            context.SaveChanges();
        }
    }
}