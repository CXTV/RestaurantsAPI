using Microsoft.EntityFrameworkCore;
using Restaurants.Application.Restaurants;
using Restaurants.Domain.Models;
using Restaurants.Infrastructure.Persistence;


namespace Restaurants.Infrastructure.Repositories
{
    internal class RestaurantsRepository : IRestaurantsRepository
    {
        private readonly RestaurantsDbContext dbContext;

        public RestaurantsRepository(RestaurantsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync()
        {
            //var restaurant = await dbContext.Restaurants.
            //Include(x => x.Dishes).ToListAsync();
            var restaurant = await dbContext.Restaurants.ToListAsync();

            return restaurant;
            //return await dbContext.Restaurants.ToListAsync();
        }

        public async Task<Restaurant> GetRestaurantByIdAsync(int id)
        {
            var restaurant = await dbContext.Restaurants.
                Include(x => x.Dishes).
                FirstOrDefaultAsync(x => x.Id == id);

            return restaurant ?? new Restaurant();
        }
    }
}
