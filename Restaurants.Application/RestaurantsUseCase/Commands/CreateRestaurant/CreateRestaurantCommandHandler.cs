using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants;
using Restaurants.Domain.Models;

namespace Restaurants.Application.RestaurantsUseCase.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, int>
    {
        private readonly IRestaurantsRepository restaurantsRepository;
        private readonly ILogger<CreateRestaurantCommandHandler> logger;
        private readonly IMapper mapper;

        public CreateRestaurantCommandHandler
        (
            IRestaurantsRepository restaurantsRepository,
            ILogger<CreateRestaurantCommandHandler> logger,
            IMapper mapper

        )
        {
            this.restaurantsRepository = restaurantsRepository;
            this.logger = logger;
            this.mapper = mapper;
        }


        public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Create a new restaurant");
            var restaurant = mapper.Map<Restaurant>(request);
            int id = await restaurantsRepository.CreateRestaurantAsync(restaurant);

            return id;
        }
    }
}
