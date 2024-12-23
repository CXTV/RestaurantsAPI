using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Users.Commands.UpdateUserDetials;

namespace Restaurants.API.Controllers
{
    [ApiController]
    [Route("api/identity")]
    public class IdentitiesController: ControllerBase
    {
        private readonly IMediator mediator;

        public IdentitiesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPatch("user")]
        [Authorize]
        public async Task<ActionResult> UpdateUserDetails(UpdateUserDetailsCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }
    }
}
