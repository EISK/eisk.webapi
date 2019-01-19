using Eisk.DataServices.EntityFrameworkCore.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Eisk.EntityFrameworkCore.Setup
{
    public class SqlServerDbContext : AppDbContext
    {
        public SqlServerDbContext() : base(new DbContextOptionsBuilder<AppDbContext>().Options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EiskSampleDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}