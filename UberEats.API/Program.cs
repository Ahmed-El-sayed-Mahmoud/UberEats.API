using Microsoft.AspNetCore.Mvc.Infrastructure;
using UberEats.Application.Extensions;
using UberEats.Infrastructure.ApplicationContext;
using UberEats.Infrastructure.Extensions;
using UberEats.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureInfrastructure( builder.Configuration.GetConnectionString("DEV")!);
builder.Services.ConfigureApplication();

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
//app.UseExceptionHandler();
//app.UseStatusCodePages();

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

app.MapControllers();

app.Run();
