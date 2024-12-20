using MediatR;
using Restaurants.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.RestaurantsUseCase.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommand:IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public bool HasDelivery { get; set; }
        public string ContactEmail { get; set; } = default!;
        public string ContactPhone { get; set; } = default!;
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? ZipCode { get; set; }
    }
}
