using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberEats.Domain.Entities;
using UberEats.Infrastructure.ApplicationContext;

namespace UberEats.Infrastructure.Seeders
{
    public class Seeder : ISeeder
    {
        private readonly ApplicationDbContext _db;

        public Seeder(ApplicationDbContext db)
        {
            this._db = db;
        }

        public async Task Seed()
        {
            if (await _db.Database.CanConnectAsync())
            {
                if (!_db.Categories.Any())
                {
                     await _db.Categories.AddRangeAsync(GetCategories());
                     await _db.SaveChangesAsync();
                }
                if (!_db.Restaurants.Any())
                {
                    await _db.Restaurants.AddRangeAsync(GetRestaurants());
                    await _db.SaveChangesAsync();
                }
            }
             

        }
        private List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>
            {
                new Category { Name = CategoryName.Sandwiches },
                new Category { Name = CategoryName.Specialties },
                new Category {  Name = CategoryName.MainCourses }
                };

            return categories;
        }

        private List<Restaurant> GetRestaurants()
        {

            return new List<Restaurant>
        {
            new Restaurant
            {

                Name ="Burger King",
                PhoneNumber = "123-456-7890",
                Rating = 4.5m,
                IsOpen = true,
                DeliveryAvailable = true,
                DeliveryFee = 2.99m,
                ContactEmail = "contact@Burger_King.com",
                Address = new Address { City="Cairo" , Country="EGY" },
                Dishes = new List<Dish>
                {
                    new Dish {  Name = "Normal Burger", Price = 9.99m, Category= new Category { Name = CategoryName.Sandwiches } },
                    new Dish { Name = "Hot Chilli Burger", Price = 12.99m ,Category= new Category { Name = CategoryName.Appetizers } }
                }
            },
            new Restaurant
            {
                Name = "KFC",
                PhoneNumber = "987-654-3210",
                Rating = 4.0m,
                IsOpen = false,
                DeliveryAvailable = false,
                DeliveryFee = null,
                ContactEmail = "contact@KFC.com",
                Address = new Address { City="Alex", Country="EGY", },
                Dishes = new List<Dish>
                {
                    new Dish {Name = "Fried Chicken Bucket", Price = 7.99m, Category= new Category { Name = CategoryName.MainCourses }},
                    new Dish { Name = "Chicken Burger", Price = 8.99m, Category= new Category { Name = CategoryName.Sides } }
                }
            }
        };

        }
    }
}
