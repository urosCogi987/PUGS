using MediatR;
using DriveEntity = TaxiApp.Domain.Entities.Drive;

namespace TaxiApp.Application.Drive.Queries.GetDriveDetails
{
    public sealed record GetDriveDetailsQuery(Guid Id) : IRequest<DriveEntity>;    
}
