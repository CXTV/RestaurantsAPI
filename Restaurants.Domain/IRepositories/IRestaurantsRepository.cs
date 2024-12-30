using Restaurants.Domain.Models;

namespace Restaurants.Application.Restaurants
{
    public interface IRestaurantsRepository
    {
        Task<int> CreateRestaurantAsync(Restaurant restaurant);
        Task Delete(Restaurant restaurant);
        Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync();
        Task<Restaurant> GetRestaurantByIdAsync(int id);
        Task UpdateRestaurant( );
        Task<IEnumerable<Restaurant>> GetAllMatchingAsync(string? searchPhrase);

    }
}
