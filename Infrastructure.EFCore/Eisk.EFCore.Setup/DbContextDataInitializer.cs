using System.Linq;

namespace Eisk.EFCore.Setup
{
    using DataServices.EFCore.DataContext;
    using Domains.TestData;

    public static class DbContextDataInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Database.EnsureCreated();

            // Look for any data available.
            if (context.Employees.Any())
            {
                return; // DB has been seeded
            }

            var employeeDataFactory = new EmployeeDataFactory();

            for (int i = 0; i < 10; i++)
                context.Employees.Add(employeeDataFactory.Factory_Entity());

            context.SaveChanges();
        }
    }
}