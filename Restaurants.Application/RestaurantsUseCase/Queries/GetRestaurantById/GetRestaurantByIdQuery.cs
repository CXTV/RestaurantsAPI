using MediatR;
using Restaurants.Application.RestaurantsUseCase.Dtos;

namespace Restaurants.Application.RestaurantsUseCase.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQuery:IRequest<RestaurantDto>
    {
        public int Id { get; set; }

        public GetRestaurantByIdQuery(int Id)
        {
            this.Id = Id;
        }
    }
}
