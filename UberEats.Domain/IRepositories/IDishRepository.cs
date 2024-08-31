using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberEats.Domain.Entities;

namespace UberEats.Domain.IRepositories
{
    public interface IDishRepository
    {
        Task<int> CreateDish(Dish dish);
        Task UpdateDish(Dish dish);
        Task <Dish> GetDishById(int id);
    }
}
