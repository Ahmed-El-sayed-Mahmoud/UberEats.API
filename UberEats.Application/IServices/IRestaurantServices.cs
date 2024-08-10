using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberEats.Application.DTOs;
using UberEats.Domain.Entities;

namespace UberEats.Application.IServices
{
    public interface IRestaurantServices
    {
        Task <IEnumerable<RestaurantDTO>>GetRestaurantsAsync ();
        Task<RestaurantDTO?> GetRestaurantByIdAsync(int id);
        Task<int> CreateAsync(CreateRestaurantDto createRestaurantDto);
    }
}
