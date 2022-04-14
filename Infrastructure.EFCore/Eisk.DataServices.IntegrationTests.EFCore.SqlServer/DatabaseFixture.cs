using Eisk.EFCore.Setup;
using System;

namespace Eisk.DataServices.IntegrationTests.EFCore.SqlServer
{
    public class DatabaseFixture : IDisposable
    {
        public DatabaseFixture()
        {
            var db = TestDbContextFactory.CreateSqlServerDbContext();
            DbContextDataInitializer.Initialize(db);
        }

        public void Dispose()
        {
            // ... clean up test data from the database ...
        }
        
    }
}
