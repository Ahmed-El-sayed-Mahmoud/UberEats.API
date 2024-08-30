using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberEats.Domain.Entities;
using UberEats.Domain.IRepositories;
using UberEats.Infrastructure.ApplicationContext;

namespace UberEats.Infrastructure.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly ApplicationDbContext _db;
       
        
        public RestaurantRepository(ApplicationDbContext applicationDbContext ) 
        {
            _db = applicationDbContext;
            
        }

        public async Task<IEnumerable<Restaurant>?> GetRestaurantsAsync()
        {
            return await _db.Restaurants
                .Include(r=>r.Dishes)
                .ThenInclude(d=>d.ImageUrls)
                .ToListAsync();
        }
        public async Task<Restaurant?> GetRestaurantByIdAsync(int id)
        {
            return await _db.Restaurants.SingleOrDefaultAsync(r => r.Id == id);
        }
        public async Task<int> Add(Restaurant entity)
        {
            await _db.Restaurants.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity.Id;
        }

        public  Restaurant? GetRestaurantByName(string name)
        {
            return _db.Restaurants.SingleOrDefault(r => r.Name == name);
        }

        public async Task DeleteRestaurantAsync(Restaurant entity)
        {
            _db.Restaurants.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
              await _db.SaveChangesAsync();
        }
    }
}
