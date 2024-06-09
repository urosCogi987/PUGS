using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaxiApp.Application.Dtos;
using TaxiApp.Infrastructure.Authentication;
using TaxiApp.Kernel.Constants;
using TaxiApp.WebApi.Models.Drive;

namespace TaxiApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class DriveController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        [HasPermission(PermissionNames.CanRequestDrive)]
        public async Task<IActionResult> Create([FromBody] CreateDriveRequest createDriveRequest)
        {
            CreatedDriveDto createdDriveDto = await mediator.Send(createDriveRequest.MapToCreateDriveCommand());
            return Ok(new DriveCreatedResponse(createdDriveDto));
        }
    }
}
