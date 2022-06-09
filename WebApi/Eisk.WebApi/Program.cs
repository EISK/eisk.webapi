using Eisk.Core.DataService;
using Eisk.Core.DataService.EFCore;
using Eisk.Core.DomainService;
using Eisk.DataServices.EFCore;
using Eisk.DataServices.EFCore.DataContext;
using Eisk.DataServices.Interfaces;
using Eisk.DomainServices;
using Eisk.EFCore.Setup;
using Eisk.WebApi.Configuration;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


builder.AddSerilogConfig(builder.Configuration);

Log.Information("Configuring web host...");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Eisk.WebApi",
        Version = "v9.0.32",
        Description = "EISK makes it easy to write scalable and secured web api on top of Microsoft's new cutting edge .net based technologies.",
        Contact = new OpenApiContact
        {
            Name = "EISK Web Api",
            Email = string.Empty,
            Url = new Uri("https://eisk.github.io")
        }
    });
});

//generic services

builder.Services.AddScoped(typeof(IEntityDataService<>), typeof(EntityDataService<>));
builder.Services.AddScoped(typeof(DomainService<,>));

//custom services

builder.Services.AddScoped<AppDbContext, InMemoryDbContext>();
builder.Services.AddScoped<IEmployeeDataService, EmployeeDataService>();
builder.Services.AddScoped<EmployeeDomainService>();

DbContextDataInitializer.Initialize(new InMemoryDbContext());

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v2");
    options.RoutePrefix = string.Empty;
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
