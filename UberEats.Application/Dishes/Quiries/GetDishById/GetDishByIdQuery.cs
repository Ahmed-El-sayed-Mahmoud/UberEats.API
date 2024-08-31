using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberEats.Application.DTOs;


namespace UberEats.Application.Dishes.Quiries.GetDishById
{
    public class GetDishByIdQuery : IRequest<DishDTO>
    {
        public int DishId { get; set; }
        public int RestaurantId { get; set; }
    }
}
