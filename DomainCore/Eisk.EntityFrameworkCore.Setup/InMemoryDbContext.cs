using Eisk.DataServices.EntityFrameworkCore.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Eisk.EntityFrameworkCore.Setup
{
    public class InMemoryDbContext : AppDbContext
    {
        public InMemoryDbContext() : base(new DbContextOptionsBuilder<AppDbContext>().Options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Eisk");
        }
    }
}