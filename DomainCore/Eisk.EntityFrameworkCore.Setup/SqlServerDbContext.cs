using Eisk.DataServices.EntityFrameworkCore.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Eisk.EntityFrameworkCore.Setup
{
    public class SqlServerDbContext : AppDbContext
    {
        private IConfiguration _configuration;
        public SqlServerDbContext(IConfiguration configuration = null) : base(new DbContextOptionsBuilder<AppDbContext>().Options)
        {
            _configuration = configuration;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration != null
                ? _configuration.GetConnectionString("DefaultSqlConnection")
                :"Server=(localdb)\\mssqllocaldb;Database=EiskDb;Trusted_Connection=True;MultipleActiveResultSets=true";

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}