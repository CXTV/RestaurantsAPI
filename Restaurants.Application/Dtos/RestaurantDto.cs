using Restaurants.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dtos
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

        public static RestaurantDto FromRestaurant(Restaurant restaurant)
        {

            return new RestaurantDto()
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Description = restaurant.Description,
                Category = restaurant.Category,
                HasDelivery = restaurant.HasDelivery,
                City = restaurant.Address?.City,
                Street = restaurant.Address?.Street,
                ZipCode = restaurant.Address?.ZipCode,
                Dishes = restaurant.Dishes.Select(DishDto.FromEntity).ToList()
            };
        }
    }
}
