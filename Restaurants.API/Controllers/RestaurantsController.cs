using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.RestaurantsUseCase.Commands.CreateRestaurant;
using Restaurants.Application.RestaurantsUseCase.Commands.DeleteRestaurant;
using Restaurants.Application.RestaurantsUseCase.Commands.UpdateRestaurant;
using Restaurants.Application.RestaurantsUseCase.Queries.GetAllRestaurants;
using Restaurants.Application.RestaurantsUseCase.Queries.GetRestaurantById;
using Restaurants.Domain.Constants;


namespace Restaurants.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RestaurantsController : ControllerBase
    {
        private readonly IMediator mediator;

        public RestaurantsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var result = await mediator.Send(new GetAllRestaurantsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "HasNationality")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await mediator.Send(new GetRestaurantByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Owner)]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand command) 
        {
            int id = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            await mediator.Send(new DeleteRestaurantCommand(id));
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateRestaurant([FromRoute] int id,UpdateRestaurantCommand command)
        {
            command.Id = id;
            await mediator.Send(command);
            return NoContent();
        }

    }
}
