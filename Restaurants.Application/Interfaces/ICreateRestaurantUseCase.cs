using Restaurants.Application.Dtos;

namespace Restaurants.Application.RestaurantsUseCase
{
    public interface ICreateRestaurantUseCase
    {
        Task<int> Execute(CreateRestaurantDto dto);
    }
}