using Restaurants.Domain.Models;


namespace Restaurants.Application.Restaurants
{
    public interface IRestaurantsRepository
    {
        Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync();
        Task<Restaurant> GetRestaurantByIdAsync(int id);
    }
}
