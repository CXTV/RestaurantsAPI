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
            return await dbContext.Restaurants.ToListAsync();
        }

        public async Task<Restaurant> GetRestaurantById(int id)
        {
            return await dbContext.Restaurants.FindAsync(id)?? new Restaurant();
            //return await dbContext.Restaurants.FirstOrDefaultAsync(x=>x.Id ==id)??new Restaurant();
        }
    }
}
