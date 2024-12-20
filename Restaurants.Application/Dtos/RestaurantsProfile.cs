
using AutoMapper;
using Restaurants.Application.RestaurantsUseCase.Commands.CreateRestaurant;
using Restaurants.Domain.Models;

namespace Restaurants.Application.Dtos
{
    public class RestaurantsProfile:Profile
    {

        public RestaurantsProfile()
        {
            CreateMap<Restaurant, RestaurantDto>()
                .ForMember(d => d.City, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.City))
                .ForMember(d => d.Street, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.Street))
                .ForMember(d => d.ZipCode, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.ZipCode))
                .ForMember(d => d.Dishes, opt => opt.MapFrom(src => src.Dishes));

            CreateMap<CreateRestaurantCommand, Restaurant>()
                .ForMember(d => d.Address, opt => opt.MapFrom(src => new Address
                {
                    City = src.City,
                    Street = src.Street,
                    ZipCode = src.ZipCode
                }));
        }
    }
}
