using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dtos;
using Restaurants.Application.Restaurants;
using Restaurants.Domain.Models;


namespace Restaurants.Application.RestaurantsUseCase
{
    internal class GetAllRestaurantsUseCase : IGetAllRestaurantsUseCase
    {
        private readonly IRestaurantsRepository restaurantsRepository;
        private readonly ILogger<GetAllRestaurantsUseCase> logger;
        private readonly IMapper mapper;

        public GetAllRestaurantsUseCase
        (
            IRestaurantsRepository restaurantsRepository,
            ILogger<GetAllRestaurantsUseCase> logger,
            IMapper mapper
        )
        {
            this.restaurantsRepository = restaurantsRepository;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<RestaurantDto>> Execute()
        {
            logger.LogInformation("Getting all restaurants");
            var restaurants = await restaurantsRepository.GetAllRestaurantsAsync();
            //var restaurantsDto = restaurants.Select(RestaurantDto.FromRestaurant);

            var restaurantsDto = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

            return restaurantsDto;
        }

    }
}
