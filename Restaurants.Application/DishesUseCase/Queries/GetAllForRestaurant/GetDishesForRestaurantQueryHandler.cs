using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.DishesUseCase.Commands.CreateDish;
using Restaurants.Application.DishesUseCase.Dtos;
using Restaurants.Application.Restaurants;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.IRepositories;

namespace Restaurants.Application.DishesUseCase.Queries.GetAllForRestaurant
{
    public class GetDishesForRestaurantQueryHandler : IRequestHandler<GetDishesForRestaurantQuery, IEnumerable<DishDto>>
    {

        private readonly IRestaurantsRepository restaurantsRepository;
        private readonly IDishesRepository dishesRepository;
        private readonly ILogger<GetDishesForRestaurantQueryHandler> logger;
        private readonly IMapper mapper;

        public GetDishesForRestaurantQueryHandler
        (
        IRestaurantsRepository restaurantsRepository,
        ILogger<GetDishesForRestaurantQueryHandler> logger,
        IMapper mapper,
        IDishesRepository dishesRepository
        )
        {
            this.restaurantsRepository = restaurantsRepository;
            this.logger = logger;
            this.mapper = mapper;
            this.dishesRepository = dishesRepository;
        }

        public async Task<IEnumerable<DishDto>> Handle(GetDishesForRestaurantQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Get dishes for restaurant with id:{RestaurantId}", request.RestaurantId);
            var restaurant = await restaurantsRepository.GetRestaurantByIdAsync(request.RestaurantId);
            if (restaurant == null)
            {
                throw new NotFoundException($"Restaurant id {request.RestaurantId} not found");
            }

            var result = mapper.Map<IEnumerable<DishDto>>(restaurant.Dishes);

            return result; 
        }
    }
}
