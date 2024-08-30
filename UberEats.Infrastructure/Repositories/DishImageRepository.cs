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
    public class DishImageRepository : IDishImageRepository
    {
        private readonly ApplicationDbContext _db;


        public DishImageRepository(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;

        }
        public async Task AddImage(DishImage image)
        {
            await _db.DishImages.AddAsync(image);
            await _db.SaveChangesAsync();
        }
    }
}
