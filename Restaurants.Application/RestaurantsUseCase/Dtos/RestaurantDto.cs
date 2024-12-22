using Restaurants.Application.DishesUseCase.Dtos;
using Restaurants.Domain.Models;
using System;
using System.Collections.Generic;


namespace Restaurants.Application.RestaurantsUseCase.Dtos
{
    public class RestaurantDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Category { get; set; } = default!;
        public bool HasDelivery { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? ZipCode { get; set; }
        public List<DishDto>? Dishes { get; set; } = [];
    }
}
