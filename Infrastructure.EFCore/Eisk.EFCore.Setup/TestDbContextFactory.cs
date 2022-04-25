using Eisk.DataServices.EFCore.DataContext;

namespace Eisk.EFCore.Setup;

public static class TestDbContextFactory
{
    public static AppDbContext CreateInMemoryDbContext()
    {
        return new InMemoryDbContext(true);
    }

    public static AppDbContext CreateSqlServerDbContext()
    {
        return new SqlServerDbContext("Server=(localdb)\\mssqllocaldb;Database=eisk;Trusted_Connection=True;MultipleActiveResultSets=true");
    }
}
