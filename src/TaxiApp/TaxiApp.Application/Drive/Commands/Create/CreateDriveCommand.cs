using MediatR;
using TaxiApp.Application.Drive.Dtos;

namespace TaxiApp.Application.Drive.Commands.Create
{
    public sealed record CreateDriveCommand(
        string FromAddress,
        string ToAddress,
        double Distance,
        int EstimatedDuration) : IRequest<CreatedDriveDto>;
}
