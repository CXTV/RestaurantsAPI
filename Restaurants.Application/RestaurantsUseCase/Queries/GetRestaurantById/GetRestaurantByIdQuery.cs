using MediatR;
using Restaurants.Application.Dtos;

namespace Restaurants.Application.RestaurantsUseCase.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQuery:IRequest<RestaurantDto>
    {
        public int Id { get; set; }
    }
}
