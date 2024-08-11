using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberEats.Domain.IRepositories;

namespace UberEats.Application.Restauransts.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler : IRequestHandler<DeleteRestaurantCommand, bool>
    {
        private readonly IRestaurantRepository  _repository;
        public DeleteRestaurantCommandHandler( IRestaurantRepository restaurantRepository)
        {
            _repository = restaurantRepository;
        }
        public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurant =await  _repository.GetRestaurantByIdAsync(request.Id);
            if (restaurant == null) 
            {
                return false;
            }
            await _repository.DeleteRestaurantAsync(restaurant);
            return true;
        }
    }
}
