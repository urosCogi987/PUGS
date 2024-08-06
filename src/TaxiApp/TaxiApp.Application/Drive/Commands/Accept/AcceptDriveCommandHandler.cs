using MediatR;
using TaxiApp.Application.Abstractions;
using TaxiApp.Domain.Entities.Enum;
using TaxiApp.Domain.Repositories;
using DriveEntity = TaxiApp.Domain.Entities.Drive;

namespace TaxiApp.Application.Drive.Commands.Accept
{
    internal sealed class AcceptDriveCommandHandler(
        IUserContext userContext,
        IDriveRepository driveRepository,
        IUserRepository userRepository) : IRequestHandler<AcceptDriveCommand>
    {
        public async Task Handle(AcceptDriveCommand request, CancellationToken cancellationToken)
        {            
            if (!userContext.IsAuthenticated)
            {
                throw new ApplicationException("User is not authenticated");
            }

            var user = await userRepository.GetItemByIdAsync(userContext.UserId);
            if (user?.UserStatus == UserStatus.Blocked)
            {
                throw new ApplicationException("User is blocked");
            }

            DriveEntity? drive = await driveRepository.GetItemByIdAsync(request.DriveId);
            if (drive is null)
            {
                throw new ApplicationException("Drive does not exist");
            }                

            drive.AcceptDrive(userContext.UserId, request.DriverArrivingTime);            

            await driveRepository.UpdateItemAsync(drive);
        }
    }
}
