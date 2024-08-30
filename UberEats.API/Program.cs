using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.FileProviders;
using Serilog;
using System.Net.NetworkInformation;
using UberEats.API.Middlewares;
using UberEats.Application.Extensions;
using UberEats.Infrastructure.ApplicationContext;
using UberEats.Infrastructure.Extensions;
using UberEats.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureInfrastructure( builder.Configuration.GetConnectionString("DEV")!);
builder.Services.ConfigureApplication();

builder.Services.AddControllers();

builder.Services.AddHttpContextAccessor(); // for Image Uploads


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ErrorHandlingMiddleware>();

/////logging
///
builder.Host.UseSerilog((context, config) =>
{
    config.ReadFrom.Configuration(context.Configuration);
});




var app = builder.Build();



app.UseSerilogRequestLogging();
app.UseSwagger();
app.UseSwaggerUI();

var scope=app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<ISeeder>();
seeder?.Seed();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider=new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/DishImages")),
     RequestPath="/wwwroot/DishImages"
});

app.MapControllers();

app.Run();
