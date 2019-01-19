using Eisk.DataServices.EntityFrameworkCore.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Eisk.EntityFrameworkCore.Setup
{
    public class SqlServerDbContext : AppDbContext
    {
        public SqlServerDbContext(IConfiguration configuration) : this(configuration.GetConnectionString("DefaultSqlConnection")) { }

        private string _connectionString;
        public SqlServerDbContext(string connectionString = null) : base(new DbContextOptionsBuilder<AppDbContext>().Options)
        {
            if (string.IsNullOrEmpty(connectionString))
                connectionString =
                    "Server=(localdb)\\mssqllocaldb;Database=EiskDb;Trusted_Connection=True;MultipleActiveResultSets=true";

            _connectionString = connectionString;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}