using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            services.AddScoped<ISeeder, Seeder>();
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
        }
    }
}
