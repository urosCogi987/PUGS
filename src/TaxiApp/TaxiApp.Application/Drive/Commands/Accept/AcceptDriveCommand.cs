using MediatR;

namespace TaxiApp.Application.Drive.Commands.Accept
{
    public sealed record AcceptDriveCommand(Guid DriveId) : IRequest;
}
