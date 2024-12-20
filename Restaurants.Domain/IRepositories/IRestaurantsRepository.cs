using Restaurants.Domain.Models;

namespace Restaurants.Application.Restaurants
{
    public interface IRestaurantsRepository
    {
        Task<int> CreateRestaurantAsync(Restaurant restaurant);
        Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync();
        Task<Restaurant> GetRestaurantByIdAsync(int id);
    }
}
