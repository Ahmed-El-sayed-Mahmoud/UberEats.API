using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberEats.Domain.Entities;

namespace UberEats.Infrastructure.ApplicationContext
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public  DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DishImage> DishImages { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions):base(dbContextOptions) 
        { 
        }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Restaurant>().OwnsOne(r => r.Address);

            modelBuilder.Entity<Restaurant>()
                .HasMany(r => r.Dishes)
                .WithOne()
                .HasForeignKey(d => d.RestaurantId);

            modelBuilder.Entity<Restaurant>()
                .HasIndex(r => r.Name)
                .IsUnique();

            modelBuilder.Entity<Dish>()
                .HasOne(d => d.Category)
                .WithMany(cat => cat.Dishes)
                .HasForeignKey(u => u.CategoryId);

            modelBuilder.Entity<DishImage>()
                .HasOne(i => i.Dish)
                .WithMany(d => d.ImageUrls)
                .HasForeignKey(i => i.DishId);

        }
    }
}
