using MediatR;
using Restaurants.Application.DishesUseCase.Dtos;


namespace Restaurants.Application.DishesUseCase.Queries.GetAllForRestaurant
{
    public class GetDishesForRestaurantQuery:IRequest<IEnumerable<DishDto>>
    {
        public int RestaurantId { get; set; }

        public GetDishesForRestaurantQuery(int restaurantId)
        {
            RestaurantId = restaurantId;
        }
    }
}
