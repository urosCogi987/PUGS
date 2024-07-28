using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaxiApp.Application.Abstractions;
using TaxiApp.Application.Users.Commands.UpdateProfilePicture;
using TaxiApp.Application.Users.Queries.GetProfile;
using TaxiApp.Application.Users.Queries.GetProfilePicture;
using TaxiApp.Application.Users.Queries.GetUser;
using TaxiApp.Application.Users.Queries.GetUserList;
using TaxiApp.Infrastructure.Authentication;
using TaxiApp.Kernel.Constants;
using TaxiApp.WebApi.Models.User;

namespace TaxiApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserController(IMediator mediator, IBlobService blobService) : ControllerBase
    {
        [HttpPut("{id}/setStatus")]
        [HasPermission(PermissionNames.RoleAdmin)]
        public async Task<IActionResult> ValidateUser(Guid id, [FromBody] SetUserStatusRequest setUserStatusRequest)
        {
            await mediator.Send(setUserStatusRequest.MapToSetUserStatusCommand(id));
            return Ok();
        }

        [HttpGet]
        [HasPermission(PermissionNames.RoleAdmin)]
        public async Task<ActionResult<List<UserListItemResponse>>> Get()
        {
            var users = await mediator.Send(new GetUserListQuery());
            return Ok(users.ConvertAll(x => new UserListItemResponse(x)));
        }

        [HttpGet("{id}")]
        [HasPermission(PermissionNames.CanUpdateProfile)]
        public async Task<ActionResult<UserProfileResponse>> Get(Guid id)
        {
            var user = await mediator.Send(new GetUserQuery(id));
            return Ok(new UserProfileResponse(user));
        }

        [HttpPut]
        [HasPermission(PermissionNames.CanUpdateProfile)]
        public async Task<IActionResult> Update(Guid id, UpdateUserProfileRequest updateUserProfileRequest)
        {
            await mediator.Send(updateUserProfileRequest.MapToUpdateUesrProfileCommand());
            return Ok();
        }

        [HttpPut("password")]
        [HasPermission(PermissionNames.CanUpdateProfile)]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequest changePasswordRequest)
        {
            await mediator.Send(changePasswordRequest.MapToChangePasswordCommand());
            return Ok();
        }

        [HttpPost("image")]
        [HasPermission(PermissionNames.CanUpdateProfile)]        
        public async Task<IActionResult> PostImage(IFormFile file)
        {            
            await mediator.Send(new UpdateProfilePictureCommand(file));
            return Ok();
        }

        [HttpGet("image")]
        [HasPermission(PermissionNames.CanUpdateProfile)]        
        public async Task<ActionResult<ProfilePictureResponse>> GetImage()
        {
            var file = await mediator.Send(new GetProfilePictureQuery());
            return Ok(new ProfilePictureResponse(file));
        }

        [HttpGet("profile")]
        [HasPermission(PermissionNames.CanUpdateProfile)]
        public async Task<ActionResult<UserProfileResponse>> GetProfile()
        {
            var user = await mediator.Send(new GetCurrentUserQuery());            
            return Ok(new UserProfileResponse(user));
        }
    }
}
