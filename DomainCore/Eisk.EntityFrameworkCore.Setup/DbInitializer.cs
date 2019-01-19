using Eisk.DataServices.EntityFrameworkCore.DataContext;
using Eisk.Domains.Employee;
using System.Linq;
using Eisk.Test.Core.DataGen;

namespace Eisk.EntityFrameworkCore.Setup
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            //context.Database.EnsureDeleted();

            context.Database.EnsureCreated();

            // Look for any data available.
            if (context.Employees.Any())
            {
                return; // DB has been seeded
            }

            for (int i = 0; i < 10; i++)
                context.Employees.Add(
                    EntityDataFactory<Employee>.Factory_Entity_Instance( 
                        x => x.Id = 0));

            context.SaveChanges();
        }
    }
}