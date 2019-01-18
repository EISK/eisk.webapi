using System;
using Eisk.DataServices.EntityFrameworkCore.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Eisk.EntityFrameworkCore.Setup
{
    public class InMemoryDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext()
        {
            return CreateDbContext(new[] { "" });
        }

        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseInMemoryDatabase("Eisk-" + Guid.NewGuid());

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}