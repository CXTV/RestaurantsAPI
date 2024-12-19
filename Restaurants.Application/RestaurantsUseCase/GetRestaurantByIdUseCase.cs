using Microsoft.Extensions.Logging;
using Restaurants.Application.Dtos;
using Restaurants.Application.Restaurants;
using Restaurants.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.RestaurantsUseCase
{
    internal class GetRestaurantByIdUseCase : IGetRestaurantByIdUseCase
    {
        private readonly IRestaurantsRepository restaurantsRepository;
        private readonly ILogger<GetAllRestaurantsUseCase> logger;

        public GetRestaurantByIdUseCase
        (
            IRestaurantsRepository restaurantsRepository,
            ILogger<GetAllRestaurantsUseCase> logger
        )
        {
            this.restaurantsRepository = restaurantsRepository;
            this.logger = logger;
        }

        public async Task<RestaurantDto> Execute(int id)
        {
            logger.LogInformation($"Getting restaurant by id:{id}");
            var restaurant = await restaurantsRepository.GetRestaurantByIdAsync(id);
            var restaurantDto = RestaurantDto.FromRestaurant(restaurant);

            return restaurantDto??new RestaurantDto();
        }
    }
}
