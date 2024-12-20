using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dtos;
using Restaurants.Application.Restaurants;
using Restaurants.Application.RestaurantsUseCase;
using Restaurants.Application.RestaurantsUseCase.Commands.CreateRestaurant;
using Restaurants.Application.RestaurantsUseCase.Commands.DeleteRestaurant;
using Restaurants.Application.RestaurantsUseCase.Queries.GetAllRestaurants;
using Restaurants.Application.RestaurantsUseCase.Queries.GetRestaurantById;
using System.Runtime.CompilerServices;


namespace Restaurants.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantsController : ControllerBase
    {

        private readonly IMediator mediator;

        public RestaurantsController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await mediator.Send(new GetAllRestaurantsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await mediator.Send(new GetRestaurantByIdQuery{ Id= id });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand command) 
        {
            int id = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            await mediator.Send(new DeleteRestaurantCommand() { Id = id});

            return Ok("200");
        }
    }
}
