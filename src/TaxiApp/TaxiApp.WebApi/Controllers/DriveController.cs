using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaxiApp.Application.Drive.Commands.Confirm;
using TaxiApp.Application.Drive.Queries.GetDriveDetails;
using TaxiApp.Application.Drive.Queries.GetDrives;
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
        public async Task<ActionResult<CreatedDriveResponse>> Create([FromBody] CreateDriveRequest createDriveRequest)
        {
            var driveDto = await mediator.Send(createDriveRequest.MapToCreateDriveCommand());
            return Ok(new CreatedDriveResponse(driveDto));
        }

        [HttpPut("{id}/confirm")]
        [HasPermission(PermissionNames.CanRequestDrive)]
        public async Task<IActionResult> Confirm(Guid id)
        {
            await mediator.Send(new ConfirmDriveCommand(id));
            return Ok();
        }

        [HttpGet]
        [HasPermission(PermissionNames.CanViewHisDrives)]
        public async Task<ActionResult<List<GetDrivesResponseListItem>>> GetDrivesForUser()
        {
            var drives = await mediator.Send(new GetDrivesQuery());
            return Ok(drives.ConvertAll(x => new GetDrivesResponseListItem(x)));
        }

        [HttpGet("{id}")]
        [HasPermission(PermissionNames.CanViewHisDrives)]
        public async Task<ActionResult<DriveDetailsResponse>> GetById(Guid id)
        {
            var drive = await mediator.Send(new GetDriveDetailsQuery(id));
            return Ok(new DriveDetailsResponse(drive));
        }

        // dole
        [HttpPut("{id}/accept")]
        [HasPermission(PermissionNames.CanAcceptDrive)]
        public async Task<IActionResult> AcceptDrive(Guid id, [FromBody] AcceptDriveRequest acceptDriveRequest) 
        {
            await mediator.Send(acceptDriveRequest.MapToAcceptDriveCommand(id));
            return Ok();
        }                        
    }
}
