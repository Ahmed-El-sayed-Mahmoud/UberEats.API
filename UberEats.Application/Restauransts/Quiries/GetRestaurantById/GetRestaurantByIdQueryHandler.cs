using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberEats.Application.DTOs;
using UberEats.Domain.Entities;
using UberEats.Domain.IRepositories;

namespace UberEats.Application.Restauransts.Quiries.GetRestaurantById
{
    public class GetRestaurantByIdQueryHandler : IRequestHandler<GetRestaurantByIdQuery, RestaurantDTO?>

    {
        private readonly IMapper _mapper;
        private readonly IRestaurantRepository _restaurantRepository;

        public GetRestaurantByIdQueryHandler(IMapper mapper, IRestaurantRepository repository)
        {
            _mapper = mapper;
            _restaurantRepository = repository;
        }
        public async Task<RestaurantDTO?> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
        {
             return _mapper.Map<RestaurantDTO>(await _restaurantRepository.GetRestaurantByIdAsync(request.Id));
  
        }
    }
}
