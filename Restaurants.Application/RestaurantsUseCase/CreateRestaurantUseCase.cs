using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dtos;
using Restaurants.Application.Restaurants;
using Restaurants.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.RestaurantsUseCase
{
    internal class CreateRestaurantUseCase : ICreateRestaurantUseCase
    {
        #region 注册服务
        private readonly IRestaurantsRepository restaurantsRepository;
        private readonly ILogger<CreateRestaurantUseCase> logger;
        private readonly IMapper mapper;

        public CreateRestaurantUseCase
        (
            IRestaurantsRepository restaurantsRepository,
            ILogger<CreateRestaurantUseCase> logger,
            IMapper mapper

        )
        {
            this.restaurantsRepository = restaurantsRepository;
            this.logger = logger;
            this.mapper = mapper;
        }
        #endregion

        public async Task<int> Execute(CreateRestaurantDto dto)
        {
            logger.LogInformation($"Create a new restaurant");

            var restaurant = mapper.Map<Restaurant>(dto);

            int id = await restaurantsRepository.CreateRestaurantAsync(restaurant);

            return id;
        }
    }
}
