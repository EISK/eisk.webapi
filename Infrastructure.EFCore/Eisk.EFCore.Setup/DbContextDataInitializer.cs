using System.Linq;

namespace Eisk.EFCore.Setup
{
    using DataServices.EFCore.DataContext;
    using Domains.TestData;
    using Eisk.Domains.Entities;
    using System.Collections.Generic;

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
            var testEmployees = new List<Employee>();

            for (int i = 0; i < 100; i++)
                testEmployees.Add(employeeDataFactory.Factory_Entity());

            context.Employees.AddRange(testEmployees);
            context.SaveChanges();

        }
    }
}