using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberEats.Domain.Entities;

namespace UberEats.Domain.IRepositories
{
    public interface IRestaurantRepository
    {
        Task <IEnumerable<Restaurant>?> GetRestaurantsAsync ();
        Task<Restaurant?> GetRestaurantByIdAsync(int  id);
        Task<int> Add(Restaurant entity);
        Restaurant? GetRestaurantByName(string name);
        Task DeleteRestaurantAsync(Restaurant restaurant);
        Task SaveChangesAsync();

    }
}
