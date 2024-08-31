using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberEats.Application.DTOs;
using UberEats.Domain.Entities;
using UberEats.Domain.Exceptions;
using UberEats.Domain.IRepositories;

namespace UberEats.Application.Dishes.Quiries.GetDishById
{
    public class GetDishByIdQueryHandler : IRequestHandler<GetDishByIdQuery,DishDTO>
    {
        private readonly IRestaurantRepository restaurantRepository;
        private readonly IMapper _mapper;
        public GetDishByIdQueryHandler(IRestaurantRepository restaurantRepository, IMapper mapper)
        {
            this.restaurantRepository = restaurantRepository;
            _mapper = mapper;
        }
        public async Task<DishDTO> Handle(GetDishByIdQuery request, CancellationToken cancellationToken)
        {
            var restuarant=await restaurantRepository.GetRestaurantByIdAsync(request.RestaurantId);
            if(restuarant == null)
            {
                throw new NotFoundException(nameof(Restaurant),request.RestaurantId.ToString());
            }
            var dish = restuarant?.Dishes?.FirstOrDefault(d => d.Id == request.DishId);
            if(dish == null)
            {
                throw new NotFoundException(nameof(Dish), request.DishId.ToString());
            }

            return _mapper.Map<DishDTO>(dish);
            
        }
    }
}
