using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaxiApp.Application.Users.Queries.GetUser;
using TaxiApp.Infrastructure.Authentication;
using TaxiApp.Kernel.Constants;
using TaxiApp.WebApi.Models.User;

namespace TaxiApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserController(IMediator mediator) : ControllerBase
    {
        [HttpPut("{id}/setStatus")]
        [HasPermission(PermissionNames.RoleAdmin)]
        public async Task<IActionResult> ValidateUser(Guid id, [FromBody] SetUserStatusRequest setUserStatusRequest)
        {
            await mediator.Send(setUserStatusRequest.MapToSetUserStatusCommand(id));
            return Ok();
        }

        [HttpGet("{id}")]
        [HasPermission(PermissionNames.CanUpdateProfile)]
        public async Task<ActionResult<UserProfileResponse>> Get(Guid id)
        {
            var user = await mediator.Send(new GetUserQuery(id));
            return Ok(new UserProfileResponse(user));
        }

        [HttpPut("{id}")]
        [HasPermission(PermissionNames.CanUpdateProfile)]
        public async Task<IActionResult> Update(Guid id, UpdateUserProfileRequest updateUserProfileRequest)
        {
            await mediator.Send(updateUserProfileRequest.MapToUpdateUesrProfileCommand(id));
            return Ok();
        }

        [HttpPut("{id}/password")]
        [HasPermission(PermissionNames.CanUpdateProfile)]
        public async Task<IActionResult> ChangePassword(Guid id, [FromBody] ChangePasswordRequest changePasswordRequest)
        {
            await mediator.Send(changePasswordRequest.MapToChangePasswordCommand(id));
            return Ok();
        }
    }
}
