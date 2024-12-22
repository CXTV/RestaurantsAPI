
using MediatR;
using Restaurants.Application.DishesUseCase.Dtos;

namespace Restaurants.Application.DishesUseCase.Queries.GetDishByIdForRestaurant
{
    public class GetDishByIdForRestaurantQuery:IRequest<DishDto>
    {
        public int RestaurantId { get; set; }
        public int DishId { get; set; }

        public GetDishByIdForRestaurantQuery(int restaurantId, int dishId)
        {
            RestaurantId = restaurantId;
            DishId = dishId;
        }

    }
}
