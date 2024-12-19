using Restaurants.Application.Dtos;
using Restaurants.Domain.Models;

namespace Restaurants.Application.RestaurantsUseCase
{
    public interface IGetRestaurantByIdUseCase
    {
        Task<RestaurantDto> Execute(int id);
    }
}