using MediatR;
using TaxiApp.Application.Drive.Dtos;

namespace TaxiApp.Application.Drive.Queries.GetDrivesForUser
{
    public sealed record GetDrivesForUserQuery() : IRequest<List<DriveListItemDto>>;
}
