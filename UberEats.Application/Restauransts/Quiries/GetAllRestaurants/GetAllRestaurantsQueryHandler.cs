using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberEats.Application.DTOs;
using UberEats.Domain.IRepositories;

namespace UberEats.Application.Restauransts.Quiries.GetAllRestaurants
{
    public class GetAllRestaurantsQueryHandler : IRequestHandler<GetAllRestaurantsQuery, IEnumerable<RestaurantDTO>?>
    {
        private readonly IMapper _mapper;
        private readonly IRestaurantRepository _restaurantRepository;

        public GetAllRestaurantsQueryHandler(IMapper mapper, IRestaurantRepository repository)
        {
            _mapper = mapper;
            _restaurantRepository = repository;
        }

        public async Task<IEnumerable<RestaurantDTO>?> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
        {
            var restaurants = await _restaurantRepository.GetRestaurantsAsync();
            if (restaurants == null || !restaurants.Any())
            {
                return null;
            }

            var restaurantsDto = _mapper.Map<IEnumerable<RestaurantDTO>>(restaurants);
            return restaurantsDto;
            
        }
    }
}
