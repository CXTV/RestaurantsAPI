using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dtos;
using Restaurants.Application.Restaurants;


namespace Restaurants.Application.RestaurantsUseCase
{
    internal class GetRestaurantByIdUseCase : IGetRestaurantByIdUseCase
    {
        private readonly IRestaurantsRepository restaurantsRepository;
        private readonly ILogger<GetAllRestaurantsUseCase> logger;
        private readonly IMapper mapper;


        public GetRestaurantByIdUseCase
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

        public async Task<RestaurantDto> Execute(int id)
        {
            logger.LogInformation($"Getting restaurant by id:{id}");
            var restaurant = await restaurantsRepository.GetRestaurantByIdAsync(id);
            //var restaurantDto = RestaurantDto.FromRestaurant(restaurant);
            var restaurantDto = mapper.Map<RestaurantDto>(restaurant);

            return restaurantDto??new RestaurantDto();
        }
    }
}
