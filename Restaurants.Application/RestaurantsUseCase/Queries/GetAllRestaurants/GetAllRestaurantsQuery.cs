using MediatR;
using Restaurants.Application.Dtos;

namespace Restaurants.Application.RestaurantsUseCase.Queries.GetAllRestaurants
{
    public class GetAllRestaurantsQuery:IRequest<IEnumerable<RestaurantDto>>
    {
    }
}
