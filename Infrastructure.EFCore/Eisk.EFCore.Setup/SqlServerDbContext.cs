using Eisk.DataServices.EFCore.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Eisk.EFCore.Setup;

public class SqlServerDbContext : AppDbContext
{
    public SqlServerDbContext(IConfiguration configuration) : this(configuration.GetConnectionString("DefaultSqlConnection")) { }

    private readonly string _connectionString;
    public SqlServerDbContext(string connectionString = null) : base(new DbContextOptionsBuilder<AppDbContext>().Options)
    {
        if (string.IsNullOrEmpty(connectionString))
            throw new ArgumentNullException(nameof(connectionString));

        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }
}
