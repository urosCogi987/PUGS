using MediatR;
using TaxiApp.Application.Abstractions;
using TaxiApp.Application.Drive.Dtos;
using TaxiApp.Domain.Repositories;

namespace TaxiApp.Application.Drive.Queries.GetDrives
{
    internal sealed class GetDrivesQueryHandler(
        IDriveRepository driveRepository,
        IUserContext userContext) : IRequestHandler<GetDrivesQuery, List<DriveListItemDto>>
    {
        public async Task<List<DriveListItemDto>> Handle(GetDrivesQuery request, CancellationToken cancellationToken)
        {
            if (!userContext.IsAuthenticated)
            {
                throw new ApplicationException("User not authenticated.");
            }                

            var drives = (await driveRepository.FindAll(x => x.DriverId == userContext.UserId || x.UserId == userContext.UserId)).ToList();

            return drives.ConvertAll(x => DriveListItemDto.Create(x.Id, x.FromAddress, x.ToAddress, x.CreatedOn, x.Status));
        }
    }
}
