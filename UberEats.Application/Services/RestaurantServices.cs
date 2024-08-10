using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using UberEats.Application.DTOs;
using UberEats.Application.IServices;
using UberEats.Domain.Entities;
using UberEats.Domain.IRepositories;

namespace UberEats.Application.Services
{
    public class RestaurantServices : IRestaurantServices
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper _mapper;
        public RestaurantServices( IRestaurantRepository restaurantRepository,IMapper mapper )
        {
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<RestaurantDTO>> GetRestaurantsAsync()
        {
            var restaurants = await _restaurantRepository.GetRestaurantsAsync();
            var restaurantsDto = _mapper.Map<IEnumerable<RestaurantDTO>>(restaurants);
            return restaurantsDto;
            
        }
        public async Task<RestaurantDTO?> GetRestaurantByIdAsync(int id)
        {
            return _mapper.Map<RestaurantDTO>( await _restaurantRepository.GetRestaurantByIdAsync(id));
        }

        public async Task<int> CreateAsync(CreateRestaurantDto createRestaurantDto)
        {
            var restaurant = _mapper.Map<Restaurant>(createRestaurantDto);
            bool Exist= _restaurantRepository.GetRestaurantByName(createRestaurantDto.Name)!=null;

            if (Exist)
                return -1;
          
            return await _restaurantRepository.Add(restaurant);
        }
    }
}
