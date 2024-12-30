using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.DishesUseCase.Commands.CreateDish;
using Restaurants.Application.Restaurants;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.IRepositories;
using Restaurants.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.DishesUseCase.Commands.DeleteDishes
{
    public class DeleteDishesForRestaurantCommandHandler : IRequestHandler<DeleteDishesForRestaurantCommand>
    {
        private readonly IRestaurantsRepository restaurantsRepository;
        private readonly IDishesRepository dishesRepository;
        private readonly ILogger<DeleteDishesForRestaurantCommandHandler> logger;
        private readonly IMapper mapper;

        public DeleteDishesForRestaurantCommandHandler
        (
            IRestaurantsRepository restaurantsRepository,
            ILogger<DeleteDishesForRestaurantCommandHandler> logger,
            IMapper mapper,
            IDishesRepository dishesRepository
        )
        {
            this.restaurantsRepository = restaurantsRepository;
            this.logger = logger;
            this.mapper = mapper;
            this.dishesRepository = dishesRepository;
        }

        public async Task Handle(DeleteDishesForRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogWarning("Removing all dishes from restaurant: {RestaurantId}", request.RestaurantId);
            var restaurant = await restaurantsRepository.GetRestaurantByIdAsync(request.RestaurantId);
            if (restaurant == null) throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());
            await dishesRepository.Delete(restaurant.Dishes);


        }

    }
}
