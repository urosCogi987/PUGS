using MediatR;
using TaxiApp.Application.Drive.Dtos;

namespace TaxiApp.Application.Drive.Queries.Get
{
    public sealed record GetDrivesQuery : IRequest<List<DriveListItemDto>>;
}
