using Eisk.Core.DataService.EFCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Eisk.WebApi
{
    using Core.DataService;
    using Core.DomainService;
    using Eisk.DataServices.EFCore;
    using Eisk.DataServices.EFCore.DataContext;
    using DataServices.Interfaces;
    using DomainServices;
    using EFCore.Setup;

    public class Startup
    {
        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            Configuration = configuration;

            DbContextDataInitializer.Initialize(new InMemoryDbContext());
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //generic services

            services.AddScoped<DbContext, InMemoryDbContext>();

            services.AddScoped(typeof(IEntityDataService<>), typeof(EntityDataService<>));

            services.AddScoped(typeof(DomainService<,>));

            //custom services

            services.AddScoped<AppDbContext, InMemoryDbContext>();

            services.AddScoped<IEmployeeDataService, EmployeeDataService>();

            services.AddScoped<EmployeeDomainService>();

            services.AddMvc();

            // Register the Swagger generator, defining 1 or more Swagger documents

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Eisk.WebApi",
                    Version = "v8.0.12",
                    Description = "EISK makes it easy to write scalable and secured web api on top of Microsoft's new cutting edge .net core technologies.",
                    Contact = new Swashbuckle.AspNetCore.Swagger.Contact
                    {
                        Name = "EISK Web Api",
                        Email = string.Empty,
                        Url = "https://eisk.github.io/eisk.webapi"
                    }
                });
            });

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Eisk.WebApi");
                c.RoutePrefix = string.Empty;
            });

            app.UseMvc();
        }
    }
}
