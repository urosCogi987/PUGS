using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaxiApp.Application.Drive.Commands.Accept;
using TaxiApp.Application.Drive.Commands.Confirm;
using TaxiApp.Application.Drive.Queries.GetDriveDetails;
using TaxiApp.Application.Drive.Queries.GetDrives;
using TaxiApp.Application.Drive.Queries.GetDrivesForUser;
using TaxiApp.Application.Drive.Queries.GetNewDrives;
using TaxiApp.Infrastructure.Authentication;
using TaxiApp.Kernel.Constants;
using TaxiApp.WebApi.Models.Drive;
using TaxiApp.WebApi.Models.User;

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

        [HttpGet("my")]
        [HasPermission(PermissionNames.CanViewHisDrives)]
        public async Task<ActionResult<List<GetDrivesResponseListItem>>> GetDrivesForUser()
        {
            var drives = await mediator.Send(new GetDrivesForUserQuery());
            return Ok(drives.ConvertAll(x => new GetDrivesResponseListItem(x)));
        }

        [HttpGet("new")]
        [HasPermission(PermissionNames.CanAcceptDrive)]
        public async Task<ActionResult<List<GetDrivesResponseListItem>>> GetNewDrives()
        {
            var drives = await mediator.Send(new GetNewDrivesQuery());
            return Ok(drives.ConvertAll(x => new GetDrivesResponseListItem(x)));
        }        

        [HttpGet]
        [HasPermission(PermissionNames.RoleAdmin)]
        public async Task<ActionResult<List<GetDrivesResponseListItem>>> GetAllDrives()
        {
            var drives = await mediator.Send(new GetDrivesQuery());
            return Ok(drives.ConvertAll(x => new GetDrivesResponseListItem(x)));
        }

        [HttpGet("{id}")]
        [HasPermission(PermissionNames.CanViewDriveDetails)]
        public async Task<ActionResult<DriveDetailsResponse>> GetById(Guid id)
        {
            var drive = await mediator.Send(new GetDriveDetailsQuery(id));
            return Ok(new DriveDetailsResponse(drive));
        }
        
        [HttpPut("{id}/accept")]
        [HasPermission(PermissionNames.CanAcceptDrive)]
        public async Task<IActionResult> AcceptDrive(Guid id) 
        {
            await mediator.Send(new AcceptDriveCommand(id));
            return Ok();
        }

        [HttpPut("{id}/rate")]
        [HasPermission(PermissionNames.CanRequestDrive)]
        public async Task<IActionResult> RateDriver(Guid id, [FromBody] RateDriverRequest rateDriverRequest)
        {
            await mediator.Send(rateDriverRequest.MapToRateDriverCommand(id));
            return Ok();
        }
    }
}
