using MediatR;
using TaxiApp.Application.Drive.Dtos;

namespace TaxiApp.Application.Drive.Queries.GetDrives
{
    public sealed record GetDrivesQuery : IRequest<List<DriveListItemDto>>;
}
