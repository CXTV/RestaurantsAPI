using Restaurants.Domain.IRepositories;
using Restaurants.Domain.Models;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories
{
    internal class DishesRepository : IDishesRepository
    {
        private readonly RestaurantsDbContext dbContext;

        public DishesRepository(RestaurantsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> CreateDishAsync(Dish dish)
        {

            using var transaction = await dbContext.Database.BeginTransactionAsync();
            try
            {
                dbContext.Dishes.Add(dish);
                await dbContext.SaveChangesAsync();

                await transaction.CommitAsync();

                return dish.Id;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }



        }
    }
}
