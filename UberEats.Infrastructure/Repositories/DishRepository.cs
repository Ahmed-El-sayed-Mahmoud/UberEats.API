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
    public class DishRepository : IDishRepository
    {
        private readonly ApplicationDbContext _db;


        public DishRepository(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;

        }
        public async Task<int> CreateDish(Dish dish)
        {
            var x= await _db.Dishes.AddAsync(dish);
            await _db.SaveChangesAsync();
            return x.Entity.Id;
        }

        public Task UpdateDish(Dish dish)
        {
            throw new NotImplementedException();
        }
    }
}
