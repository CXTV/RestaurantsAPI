using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants;


namespace Restaurants.Application.RestaurantsUseCase.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler : IRequestHandler<DeleteRestaurantCommand, bool>
    {
        private readonly IRestaurantsRepository restaurantsRepository;
        private readonly ILogger<DeleteRestaurantCommandHandler> logger;
        private readonly IMapper mapper;

        public DeleteRestaurantCommandHandler
        (
            IRestaurantsRepository restaurantsRepository,
            ILogger<DeleteRestaurantCommandHandler> logger,
            IMapper mapper

        )
        {
            this.restaurantsRepository = restaurantsRepository;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Delete restaurant by id:{request.Id}");
            var restaurant = await restaurantsRepository.GetRestaurantByIdAsync(request.Id);
            if (restaurant is null)
                return false;
            await restaurantsRepository.Delete(restaurant);
            return true;
        }
    }
}
