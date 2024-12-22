using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants;
using Restaurants.Domain.IRepositories;
using Restaurants.Domain.Models;

namespace Restaurants.Application.DishesUseCase.Commands.CreateDish
{
    public class CreateDishCommandHandler : IRequestHandler<CreateDishCommand>
    {
        private readonly IRestaurantsRepository restaurantsRepository;
        private readonly IDishesRepository dishesRepository;
        private readonly ILogger<CreateDishCommandHandler> logger;
        private readonly IMapper mapper;

        public CreateDishCommandHandler
        (
            IRestaurantsRepository restaurantsRepository,
            ILogger<CreateDishCommandHandler> logger,
            IMapper mapper,
            IDishesRepository dishesRepository


        )
        {
            this.restaurantsRepository = restaurantsRepository;
            this.logger = logger;
            this.mapper = mapper;
            this.dishesRepository = dishesRepository;
        }

        public async Task Handle(CreateDishCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating dish with : {@DishRequest}",request);
            var restaurant = restaurantsRepository.GetRestaurantByIdAsync(request.restaurantId);
            if(restaurant == null)
            {
                throw new Exception($"Restaurant {request.restaurantId} not found");
            }

            var dish = mapper.Map<Dish>(request);
            await dishesRepository.CreateDishAsync(dish);

        }
    }
}
