using MediatR;
using Restaurants.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.RestaurantsUseCase.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQuery:IRequest<RestaurantDto>
    {
        public int Id { get; set; }
    }
}
