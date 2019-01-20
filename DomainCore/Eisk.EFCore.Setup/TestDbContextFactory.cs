using Eisk.DataServices.EntityFrameworkCore.DataContext;

namespace Eisk.EntityFrameworkCore.Setup
{
    public static class TestDbContextFactory
    {
        public static AppDbContext CreateDbContext()
        {
            return new InMemoryDbContext(true);
        }
    }
}