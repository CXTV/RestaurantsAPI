using Restaurants.Domain.Models;

namespace Restaurants.Application.DishesUseCase.Dtos
{
    public class DishDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }

        public int? Kilocalories { get; set; }


    }
}
