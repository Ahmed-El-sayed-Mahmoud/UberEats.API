using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UberEats.Domain.Entities;
using UberEats.Domain.IRepositories;
using UberEats.Infrastructure.ApplicationContext;
using UberEats.Infrastructure.Repositories;
using UberEats.Infrastructure.Seeders;

namespace UberEats.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureInfrastructure(this IServiceCollection services , string ConnectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(ConnectionString);
            });
            services.AddIdentity<User,IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();


            services.AddScoped<ISeeder, Seeder>();
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<IDishRepository, DishRepository>();
            services.AddScoped<IDishImageRepository, DishImageRepository>();
        }
    }
}
