using Restaurants.Application.Dtos;
using Restaurants.Domain.Models;

namespace Restaurants.Application.RestaurantsUseCase
{
    public interface IGetAllRestaurantsUseCase
    {
        Task<IEnumerable<RestaurantDto>> Execute();
    }
}