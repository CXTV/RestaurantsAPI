using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants;
using Restaurants.Application.RestaurantsUseCase.Commands.CreateRestaurant;
using Restaurants.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.RestaurantsUseCase.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommandHandler : IRequestHandler<UpdateRestaurantCommand>
    {
        private readonly IRestaurantsRepository restaurantsRepository;
        private readonly ILogger<UpdateRestaurantCommandHandler> logger;
        private readonly IMapper mapper;

        public UpdateRestaurantCommandHandler
        (
            IRestaurantsRepository restaurantsRepository,
            ILogger<UpdateRestaurantCommandHandler> logger,
            IMapper mapper
        )
        {
            this.restaurantsRepository = restaurantsRepository;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            {
                logger.LogInformation("Update restaurant by id:{RestaurantId} with{@UpdateRestaurant}",request.Id,request);
                var restaurant = await restaurantsRepository.GetRestaurantByIdAsync(request.Id);
                if (restaurant is null)
                    throw new NotFoundException(nameof(restaurant), $"Restaurant id {request.Id} not found");

                restaurant = mapper.Map(request, restaurant);
                await restaurantsRepository.UpdateRestaurant();
            }
        }
    }
}
