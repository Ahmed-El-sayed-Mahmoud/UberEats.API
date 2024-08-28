using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberEats.Domain.Entities;
using UberEats.Domain.Exceptions;
using UberEats.Domain.IRepositories;

namespace UberEats.Application.Restauransts.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler : IRequestHandler<DeleteRestaurantCommand>
    {
        private readonly IRestaurantRepository  _repository;
        public DeleteRestaurantCommandHandler( IRestaurantRepository restaurantRepository)
        {
            _repository = restaurantRepository;
        }
        public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurant =await  _repository.GetRestaurantByIdAsync(request.Id);
            if (restaurant == null) 
            {
                throw new NotFoundException(nameof(Restaurant), request.Id.ToString());
            }
            await _repository.DeleteRestaurantAsync(restaurant);

        }
    }
}
