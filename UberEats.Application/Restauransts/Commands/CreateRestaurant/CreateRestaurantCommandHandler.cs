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

namespace UberEats.Application.Restauransts.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IRestaurantRepository _restaurantRepository;

        public CreateRestaurantCommandHandler(IMapper mapper, IRestaurantRepository repository)
        {
            _mapper = mapper;  
            _restaurantRepository = repository;
        }
       

        public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
          var restaurant = _mapper.Map<Restaurant>(request);
            bool Exist = _restaurantRepository.GetRestaurantByName(request.Name) != null;

            if (Exist)
                return -1;

            return  await _restaurantRepository.Add(restaurant);
        }
    }
}
