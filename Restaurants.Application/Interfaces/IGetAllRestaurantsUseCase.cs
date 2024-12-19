using Restaurants.Application.Dtos;

namespace Restaurants.Application.RestaurantsUseCase
{
    public interface IGetAllRestaurantsUseCase
    {
        Task<IEnumerable<RestaurantDto>> Execute();
    }
}