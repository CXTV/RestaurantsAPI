using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Users.Commands.AssignUserRole;
using Restaurants.Application.Users.Commands.UnassignUserRole;
using Restaurants.Application.Users.Commands.UpdateUserDetials;
using Restaurants.Domain.Constants;

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
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult> UpdateUserDetails(UpdateUserDetailsCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

        [HttpPatch("userRole")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult> AssignUserRole(AssignUserRoleCommand command )
        {
            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("userRole")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> UnassignUserRole(UnassignUserRoleCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }


    }
}
