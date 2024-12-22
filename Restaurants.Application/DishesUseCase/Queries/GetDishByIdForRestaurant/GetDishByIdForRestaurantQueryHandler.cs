
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.DishesUseCase.Dtos;
using Restaurants.Application.DishesUseCase.Queries.GetAllForRestaurant;
using Restaurants.Application.Restaurants;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.IRepositories;
using Restaurants.Domain.Models;

namespace Restaurants.Application.DishesUseCase.Queries.GetDishByIdForRestaurant
{
    public class GetDishByIdForRestaurantQueryHandler : IRequestHandler<GetDishByIdForRestaurantQuery, DishDto>
    {

        private readonly IRestaurantsRepository restaurantsRepository;
        private readonly IDishesRepository dishesRepository;
        private readonly ILogger<GetDishByIdForRestaurantQueryHandler> logger;
        private readonly IMapper mapper;

        public GetDishByIdForRestaurantQueryHandler
        (
        IRestaurantsRepository restaurantsRepository,
        ILogger<GetDishByIdForRestaurantQueryHandler> logger,
        IMapper mapper,
        IDishesRepository dishesRepository
        )
        {
            this.restaurantsRepository = restaurantsRepository;
            this.logger = logger;
            this.mapper = mapper;
            this.dishesRepository = dishesRepository;
        }

        public async Task<DishDto> Handle(GetDishByIdForRestaurantQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Retrieving dish: {DishId}, for restaurant with id: {RestaurantId}",
                request.DishId,
                request.RestaurantId);
            var restaurant = await restaurantsRepository.GetRestaurantByIdAsync(request.RestaurantId);
            if (restaurant == null) throw new NotFoundException("restaurant not found");
            var dish = restaurant.Dishes.FirstOrDefault(d => d.Id == request.DishId);
            if (dish == null) throw new NotFoundException("dish not found");
            var result = mapper.Map<DishDto>(dish);
            return result;
        }
    }
}
