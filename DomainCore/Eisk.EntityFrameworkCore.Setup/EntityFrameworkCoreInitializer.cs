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

        private readonly IServiceCollection _services;
        private readonly IConfiguration _configuration;

        public EntityFrameworkCoreInitializer(IServiceCollection services, IConfiguration configuration)
        {
            _services = services;
            _configuration = configuration;
        }

        private IHostingEnvironment _hostingEnvironment;
        public IHostingEnvironment HostingEnvironment
        {
            get
            {
                if (_hostingEnvironment == null)
                {
                    IServiceProvider serviceProvider = _services.BuildServiceProvider();
                    _hostingEnvironment = serviceProvider.GetService<IHostingEnvironment>();
                }
                return _hostingEnvironment;
            }
        }

        public void AddDbContext()
        {
            if (!HostingEnvironment.IsDevelopment())
                _services.AddScoped<AppDbContext, InMemoryDbContext>();
            else
                _services.AddTransient<AppDbContext>(x => new SqlServerDbContext(_configuration));
        }

        public static void AddSeedDataToDbContext(IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            if (!hostingEnvironment.IsDevelopment())
                DbContextDataInitializer.Initialize(new InMemoryDbContext());
            else
                DbContextDataInitializer.Initialize(new SqlServerDbContext(configuration));

        }
    }
}