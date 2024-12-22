using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.DishesUseCase.Commands.CreateDish
{
    public class CreateDishCommand:IRequest
    {

        public int restaurantId { get; set; }

        public CreateDishCommand(int restaurantId)
        {
            this.restaurantId = restaurantId;
        }

        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }

        public int? Kilocalories { get; set; }

    }
}
