using Eisk.DataServices.EntityFrameworkCore;
using Eisk.DataServices.Interfaces;
using Eisk.DomainServices;
using Eisk.EntityFrameworkCore.Setup;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eisk.WebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            Configuration = configuration;

            EntityFrameworkCoreInitializer.AddSeedDataToDbContext(env, configuration);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            EntityFrameworkCoreInitializer.Factory(services, Configuration).AddDbContext();

            services.AddTransient<IEmployeeDataService, EmployeeDataService>();

            services.AddTransient<EmployeeDomainService>();

            services.AddMvc();

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
