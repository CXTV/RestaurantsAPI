

using AutoMapper;
using Restaurants.Domain.Models;

namespace Restaurants.Application.Dtos
{
    public class DishesProfile: Profile
    {
        public DishesProfile()
        {
            CreateMap<Dish, DishDto>();           
        }
    }
}
