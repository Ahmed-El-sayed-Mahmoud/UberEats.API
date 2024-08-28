using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberEats.Domain.Entities;
using UberEats.Domain.Exceptions;
using UberEats.Domain.IRepositories;

namespace UberEats.Application.Restauransts.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommandHandler : IRequestHandler<UpdateRestaurantCommand>
    {
        private readonly IMapper _mapper;
        private readonly IRestaurantRepository _repository;
        public UpdateRestaurantCommandHandler(IRestaurantRepository restaurantRepository,IMapper mapper )
        {
            _repository = restaurantRepository;
            _mapper = mapper;
        }
        public async Task Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
           
            var restaurant =await  _repository.GetRestaurantByIdAsync( request.Id );
            if (restaurant == null)
            {
                throw new NotFoundException(nameof (Restaurant),request.Id.ToString());
            }
            _mapper.Map(request,restaurant);
            await _repository.SaveChangesAsync();

        }
    }
}
