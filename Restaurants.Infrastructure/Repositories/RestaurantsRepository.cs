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

        public async Task<int> CreateRestaurantAsync(Restaurant restaurant)
        {
            using var transaction = await dbContext.Database.BeginTransactionAsync();
            try
            {
                dbContext.Restaurants.Add(restaurant);
                await dbContext.SaveChangesAsync();

                await transaction.CommitAsync();

                return restaurant.Id;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw; 
            }

        }

        public Task Delete(Restaurant restaurant)
        {
            dbContext.Restaurants.Remove(restaurant);
            return dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Restaurant>> GetAllMatchingAsync(string? searchPhrase)
        {
            var searchPhraseLower = searchPhrase?.ToLower();
            var restaurants = await dbContext
                .Restaurants
                .Where(r => searchPhraseLower == null 
                    || (r.Name.ToLower().Contains(searchPhraseLower)
                    || r.Description.ToLower().Contains(searchPhraseLower))
                ).ToListAsync();

            return restaurants;
        }

        public async Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync()
        {
            var restaurant = await dbContext.Restaurants.ToListAsync();
            return restaurant;
        }

        public async Task<Restaurant> GetRestaurantByIdAsync(int id)
        {
            var restaurant = await dbContext.Restaurants.
                Include(x => x.Dishes).
                FirstOrDefaultAsync(x => x.Id == id);

            return restaurant;
        }

        public Task UpdateRestaurant() => dbContext.SaveChangesAsync();

    }
}
