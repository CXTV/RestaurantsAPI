using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Restaurants;
using Restaurants.Infrastructure.Persistence;
using Restaurants.Infrastructure.Repositories;
using Restaurants.Infrastructure.Seeds;

namespace Restaurants.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("RestaurantsDB");
            services.AddDbContext<RestaurantsDbContext>(options =>
            {
                options.UseSqlServer(connectionString).EnableSensitiveDataLogging();
            });

            services.AddScoped<IRestaurantsRepository, RestaurantsRepository>();
            services.AddScoped<IRestaurantSeeds, RestaurantSeeds>();
        }
    }
}
