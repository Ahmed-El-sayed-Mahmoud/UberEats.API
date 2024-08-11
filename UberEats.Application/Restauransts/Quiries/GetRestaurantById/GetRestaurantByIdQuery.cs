using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberEats.Application.DTOs;

namespace UberEats.Application.Restauransts.Quiries.GetRestaurantById
{
    public class GetRestaurantByIdQuery:IRequest<RestaurantDTO?>
    {
        public int Id { get; }
        public GetRestaurantByIdQuery(int id)
        {
            Id = id;
        }
    }
}
