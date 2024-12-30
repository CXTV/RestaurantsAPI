using Restaurants.Domain.Models;

namespace Restaurants.Domain.IRepositories
{
    public interface IDishesRepository
    {
        Task<int> CreateDishAsync(Dish dish);
        Task Delete(List<Dish> dishes);
    }
}
