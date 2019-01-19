using Eisk.DataServices.EntityFrameworkCore.DataContext;
using Eisk.Domains.Employee;
using System.Linq;
using Eisk.Test.Core.DataGen;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.AspNetCore.Hosting;

namespace Eisk.EntityFrameworkCore.Setup
{
    public static class EntityFrameworkCoreInitializer
    {
        public static void Initialize(IServiceCollection services)
        {
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            IHostingEnvironment env = serviceProvider.GetService<IHostingEnvironment>();

            if (env.IsDevelopment())
            {
                services.AddDbContext<InMemoryDbContext>();
                services.AddTransient<AppDbContext, InMemoryDbContext>();
            }
            else
            {
                services.AddDbContext<SqlServerDbContext>();//pass iconfiguration
                services.AddTransient<AppDbContext, SqlServerDbContext>();
            }

        }
    }
}