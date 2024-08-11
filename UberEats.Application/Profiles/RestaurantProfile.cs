using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberEats.Application.DTOs;
using UberEats.Application.Restauransts.Commands.CreateRestaurant;
using UberEats.Application.Restauransts.Commands.UpdateRestaurant;
using UberEats.Application.Restauransts.Quiries.GetAllRestaurants;
using UberEats.Domain.Entities;

namespace UberEats.Application.Profiles
{
    public class RestaurantProfile : Profile
    {
        public RestaurantProfile()
        {
            CreateMap<UpdateRestaurantCommand, Restaurant>();

            CreateMap<Restaurant, RestaurantDTO>()
                .ForMember(d => d.Street, opt => opt.MapFrom(src => src.Address!.Street == null ? null : src.Address.Street))
                .ForMember(d => d.City, opt => opt.MapFrom(src => src.Address!.City == null ? null : src.Address.City))
                .ForMember(d => d.State, opt => opt.MapFrom(src => src.Address!.State == null ? null : src.Address.State))
                .ForMember(d => d.PostalCode, opt => opt.MapFrom(src => src.Address!.PostalCode == null ? null : src.Address.PostalCode))
                .ForMember(d => d.Country, opt => opt.MapFrom(src => src.Address!.Country == null ? null : src.Address.Country))
                .ForMember(d => d.Dishes, opt => opt.MapFrom(src => src.Dishes));

            CreateMap<CreateRestaurantCommand, Restaurant>()
                .ForMember(r => r.Address, opt => opt.MapFrom(dto => new Address
                {
                    City = dto.City,
                    State = dto.State,
                    PostalCode = dto.PostalCode,
                    Country = dto.Country,
                    Street=dto.Street,
                }));
                


        }
    }
}
