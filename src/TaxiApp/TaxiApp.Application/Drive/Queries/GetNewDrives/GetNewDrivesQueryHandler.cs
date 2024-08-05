using MediatR;
using TaxiApp.Application.Abstractions;
using TaxiApp.Application.Drive.Dtos;
using TaxiApp.Domain.Repositories;

namespace TaxiApp.Application.Drive.Queries.GetNewDrives
{
    internal sealed class GetNewDrivesQueryHandler(
        IDriveRepository driveRepository,
        IUserContext userContext) : IRequestHandler<GetNewDrivesQuery, List<DriveListItemDto>>
    {
        public async Task<List<DriveListItemDto>> Handle(GetNewDrivesQuery request, CancellationToken cancellationToken)
        {
            if (!userContext.IsAuthenticated)
            {
                throw new ApplicationException("User not authenticated.");
            }

            var drives = (await driveRepository.GetNewDrives()).ToList();

            return drives.ConvertAll(x => DriveListItemDto.Create(x.Id, x.FromAddress, x.ToAddress, x.CreatedOn, x.Status));
        }
    }
}
