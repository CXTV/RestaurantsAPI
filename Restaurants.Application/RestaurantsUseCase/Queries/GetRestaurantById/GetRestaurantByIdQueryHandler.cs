﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants;
using Restaurants.Application.RestaurantsUseCase.Dtos;
using Restaurants.Application.RestaurantsUseCase.Queries.GetAllRestaurants;
using Restaurants.Domain.Exceptions;

namespace Restaurants.Application.RestaurantsUseCase.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQueryHandler : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto>
    {
        private readonly IRestaurantsRepository restaurantsRepository;
        private readonly ILogger<GetRestaurantByIdQueryHandler> logger;
        private readonly IMapper mapper;

        public GetRestaurantByIdQueryHandler
        (
            IRestaurantsRepository restaurantsRepository,
            ILogger<GetRestaurantByIdQueryHandler> logger,
            IMapper mapper

        )
        {
            this.restaurantsRepository = restaurantsRepository;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<RestaurantDto> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting restaurant by id:{RestaurantId}",request.Id);

            var restaurant = await restaurantsRepository.GetRestaurantByIdAsync(request.Id)
                                ??throw new NotFoundException($"Restaurant id {request.Id} not found");
            
            var restaurantDto = mapper.Map<RestaurantDto>(restaurant);

            return restaurantDto ;
        }
    }
}
