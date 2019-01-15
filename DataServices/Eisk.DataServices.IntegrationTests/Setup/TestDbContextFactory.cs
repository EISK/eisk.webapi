//using System;

//namespace Eisk.DataServices.IntegrationTests.Setup
//{
//    public class TestDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
//    {
//        public AppDbContext CreateDbContext()
//        {
//            return CreateDbContext(new[] {""});
//        }

//        public AppDbContext CreateDbContext(string[] args)
//        {
//            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
//            optionsBuilder.UseInMemoryDatabase("MyDb" + Guid.NewGuid());

//            return new AppDbContext(optionsBuilder.Options);
//        }
//    }
//}