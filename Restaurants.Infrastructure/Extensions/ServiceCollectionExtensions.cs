using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Restaurants;
using Restaurants.Domain.Entities;
using Restaurants.Domain.IRepositories;
using Restaurants.Infrastructure.Authorization;
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

            services.AddIdentityApiEndpoints<User>()
                .AddRoles<IdentityRole>()
                .AddClaimsPrincipalFactory<RestaurantsUserClaimsPrincipalFactory>()
                .AddEntityFrameworkStores<RestaurantsDbContext>();

            services.AddScoped<IRestaurantsRepository, RestaurantsRepository>();
            services.AddScoped<IRestaurantSeeds, RestaurantSeeds>();
            services.AddScoped<IDishesRepository, DishesRepository>();
            services.AddAuthorizationBuilder()
                //.AddPolicy("HasNationnality", builder => builder.RequireClaim("Nationality"));
                .AddPolicy(PolicyNames.HasNationality, builder => builder.RequireClaim(AppClaimTypes.Nationality));



        }
    }
}
