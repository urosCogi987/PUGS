using MediatR;

namespace TaxiApp.Application.Drive.Commands.Confirm
{
    public sealed record ConfirmDriveCommand(Guid Id) : IRequest;    
}
