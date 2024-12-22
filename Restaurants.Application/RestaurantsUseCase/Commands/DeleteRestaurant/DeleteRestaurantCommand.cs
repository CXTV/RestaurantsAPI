using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.RestaurantsUseCase.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommand:IRequest
    {
        public int Id { get; set; }
        public DeleteRestaurantCommand(int Id)
        {
            this.Id = Id;
        }
    }
}
