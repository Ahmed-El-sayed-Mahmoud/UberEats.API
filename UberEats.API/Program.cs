using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Net.NetworkInformation;
using UberEats.API.Middlewares;
using UberEats.Application.Extensions;
using UberEats.Domain.Entities;
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
builder.Services.AddSwaggerGen(c =>
{
    
    c.AddSecurityDefinition("bearerAuth", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",  
        In = ParameterLocation.Header, 
        Type = SecuritySchemeType.Http, 
        Scheme = "Bearer"  
    });

    // Define the security requirement (i.e., the need to use the above scheme)
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "bearerAuth"  // The ID must match the one defined above
                }
            },
            new string[] {}  // Scopes - empty if none are defined
        }
    });
});


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

app.MapGroup("api/identity").MapIdentityApi<User>();

app.UseAuthentication();

app.UseAuthorization();


app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider=new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/DishImages")),
     RequestPath="/wwwroot/DishImages"
});

app.MapControllers();

app.Run();
