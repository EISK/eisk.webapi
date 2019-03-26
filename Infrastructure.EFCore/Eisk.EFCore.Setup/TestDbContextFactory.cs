using Eisk.DataServices.EFCore.DataContext;

namespace Eisk.EFCore.Setup
{
    public static class TestDbContextFactory
    {
        public static AppDbContext CreateDbContext()
        {
            return new InMemoryDbContext(true);
        }
    }
}