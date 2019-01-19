using Eisk.DataServices.EntityFrameworkCore.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Eisk.EntityFrameworkCore.Setup
{
    public class SqlServerDbContext : AppDbContext
    {
        private IConfiguration _configuration;

        public SqlServerDbContext(IConfiguration configuration) : base(new DbContextOptionsBuilder<AppDbContext>().Options)
        {
            _configuration = configuration;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultSqlConnection"));
        }
    }
}