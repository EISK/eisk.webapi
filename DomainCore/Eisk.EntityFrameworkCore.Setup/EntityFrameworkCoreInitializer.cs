using Eisk.DataServices.EntityFrameworkCore.DataContext;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Eisk.EntityFrameworkCore.Setup
{
    public class EntityFrameworkCoreInitializer
    {
        public static EntityFrameworkCoreInitializer Factory(IServiceCollection services, IConfiguration configuration)
        {
            return new EntityFrameworkCoreInitializer(services, configuration);
        }

        private IServiceCollection _services;
        private IConfiguration _configuration;
        private IHostingEnvironment _hostingEnvironment;
        public EntityFrameworkCoreInitializer(IServiceCollection services, IConfiguration configuration)
        {
            _services = services;
            _configuration = configuration;

            IServiceProvider serviceProvider = _services.BuildServiceProvider();
            _hostingEnvironment = serviceProvider.GetService<IHostingEnvironment>();
        }

        public void AddDbContext()
        {
            if (_hostingEnvironment.IsDevelopment())
                _services.AddScoped<AppDbContext, InMemoryDbContext>();
            else
                _services.AddScoped<AppDbContext>(x => new SqlServerDbContext(_configuration));
        }

        public static void AddSeedDataToDbContext(IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            if (hostingEnvironment.IsDevelopment())
                DbContextDataInitializer.Initialize(new InMemoryDbContext());
            else
                DbContextDataInitializer.Initialize(new SqlServerDbContext(configuration));

        }
    }
}