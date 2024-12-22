﻿using Restaurants.Domain.Models;


namespace Restaurants.Application.RestaurantsUseCase.Dtos
{
    public class CreateRestaurantDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Category { get; set; } = default!;
        public bool HasDelivery { get; set; }
        public string ContactEmail { get; set; } = default!;
        public string ContactPhone { get; set; } = default!;

        public string? City { get; set; }
        public string? Street { get; set; }
        public string? ZipCode { get; set; }

    }
}