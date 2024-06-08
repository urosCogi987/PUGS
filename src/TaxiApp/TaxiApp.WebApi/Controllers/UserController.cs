using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaxiApp.Application.Users.Queries.GetUser;
using TaxiApp.Infrastructure.Authentication;
using TaxiApp.Kernel.Constants;
using TaxiApp.WebApi.Models;

namespace TaxiApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class UserController(IMediator mediator) : ControllerBase
    {
        [HttpPut("{id}/setStatus")]
        //[HasPermission(PermissionNames.RoleAdmin)]
        public async Task<IActionResult> ValidateUser(Guid id, SetUserStatusRequest setUserStatusRequest)
        {
            await mediator.Send(setUserStatusRequest.MapToSetUserStatusCommand(id));
            return Ok();
        }

        [HttpGet("{id}")]
        //[HasPermission(PermissionNames.TestPermission)]
        public async Task<IActionResult> Get(Guid id)
        {
            var user = await mediator.Send(new GetUserQuery(id));
            return Ok(new UserProfileResponse(user));
        }
    }
}
