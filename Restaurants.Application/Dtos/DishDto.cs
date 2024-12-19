﻿using Restaurants.Domain.Models;

namespace Restaurants.Application.Dtos
{
    public class DishDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }

        public int? Kilocalories { get; set; }

        public static DishDto FromEntity(Dish dish)
        {
            return new DishDto()
            {
                Id = dish.Id,
                Name = dish.Name,
                Description = dish.Description,
                Price = dish.Price,
                Kilocalories = dish.Kilocalories
            };
        }

    }
}
