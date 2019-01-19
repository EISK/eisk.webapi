using Eisk.DataServices.EntityFrameworkCore.DataContext;
using Microsoft.EntityFrameworkCore;
using System;

namespace Eisk.EntityFrameworkCore.Setup
{
    public class InMemoryDbContext : AppDbContext
    {
        private readonly bool _uniqueDbName;
        public InMemoryDbContext(bool uniqueDbName = false) : base(new DbContextOptionsBuilder<AppDbContext>().Options)
        {
            _uniqueDbName = uniqueDbName;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbName = "Eisk" + (_uniqueDbName ? Guid.NewGuid().ToString() : string.Empty);

            optionsBuilder.UseInMemoryDatabase(dbName);
        }
    }
}