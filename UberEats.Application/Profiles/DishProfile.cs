using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberEats.Application.DTOs;
using UberEats.Domain.Entities;

namespace UberEats.Application.Profiles
{
    public class DishProfile:Profile
    {
        public DishProfile()
        {
            CreateMap<Dish, DishDTO>()
                .ForMember(d => d.CategoryId, opt => opt.MapFrom(src => src.CategoryId));
                


        }
    }
}
