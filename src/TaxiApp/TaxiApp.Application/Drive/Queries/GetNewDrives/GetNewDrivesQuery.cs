using MediatR;
using TaxiApp.Application.Drive.Dtos;

namespace TaxiApp.Application.Drive.Queries.GetNewDrives
{
    public sealed record GetNewDrivesQuery: IRequest<List<DriveListItemDto>>;    
}
