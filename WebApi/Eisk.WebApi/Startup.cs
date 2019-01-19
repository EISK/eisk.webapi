﻿using Eisk.DataServices.EntityFrameworkCore;
using Eisk.DataServices.EntityFrameworkCore.DataContext;
using Eisk.DataServices.Interfaces;
using Eisk.EntityFrameworkCore.Setup;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eisk.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            DbInitializer.Initialize(new InMemoryDbContext());
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<InMemoryDbContext>();

            services.AddTransient<AppDbContext, InMemoryDbContext>();

            services.AddTransient<IEmployeeDataService, EmployeeDataService>();

            //services.AddTransient<EmployeeDomainService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
