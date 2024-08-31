using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberEats.Application.Dishes.Commands.CreateDish;
using UberEats.Application.DTOs;
using UberEats.Domain.Entities;

namespace UberEats.Application.Profiles
{
    public class DishImageProfile : Profile
    {
        public DishImageProfile()
        {
            CreateMap<DishImage, DishImageDto>();
        }
    }
}
