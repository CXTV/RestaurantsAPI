using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.RestaurantsUseCase;


namespace Restaurants.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IGetAllRestaurantsUseCase, GetAllRestaurantsUseCase>();
            services.AddScoped<IGetRestaurantByIdUseCase, GetRestaurantByIdUseCase>();

            services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);
        }
    }
}
