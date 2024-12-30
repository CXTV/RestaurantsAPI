using AutoMapper;
using Restaurants.Application.DishesUseCase.Commands.CreateDish;
using Restaurants.Domain.Models;

namespace Restaurants.Application.DishesUseCase.Dtos
{
    public class DishesProfile : Profile
    {
        public DishesProfile()
        {
            CreateMap<Dish, DishDto>();

            CreateMap<CreateDishCommand, Dish>();

        }
    }
}
