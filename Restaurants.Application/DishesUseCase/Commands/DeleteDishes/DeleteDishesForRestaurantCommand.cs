using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.DishesUseCase.Commands.DeleteDishes
{
    public class DeleteDishesForRestaurantCommand: IRequest
    {
        public int RestaurantId { get; set; }

        public DeleteDishesForRestaurantCommand(int restaurantId)
        {
            RestaurantId = restaurantId;
        }
    }
}
