using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberEats.Domain.Entities;
using UberEats.Domain.IRepositories;

namespace UberEats.Application.Dishes.Commands.CreateDish
{
    public class CreateDishCommandHandler : IRequestHandler<CreateDishCommand, int>
    {
        private readonly IDishRepository _dishRepository;
        private readonly IMapper _mapper;
        public CreateDishCommandHandler(IDishRepository dishRepository,IMapper mapper)
        {
            _dishRepository = dishRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateDishCommand request, CancellationToken cancellationToken)
        {
           var dish= _mapper.Map<Dish>(request);
           return await _dishRepository.CreateDish(dish);

        }
    }
}
