using MediatR;
using TaxiApp.Application.Abstractions;
using TaxiApp.Domain.Repositories;
using DriveEntity = TaxiApp.Domain.Entities.Drive;

namespace TaxiApp.Application.Drive.Commands.Accept
{
    internal sealed class AcceptDriveCommandHandler(
        IUserContext userContext,
        IDriveRepository driveRepository) : IRequestHandler<AcceptDriveCommand>
    {
        public async Task Handle(AcceptDriveCommand request, CancellationToken cancellationToken)
        {
            //
            //User? user = await userRepository.GetItemByIdAsync(request.UserId);

            DriveEntity? drive = await driveRepository.GetItemByIdAsync(request.DriveId);
            if (drive is null)
                throw new ApplicationException("Drive does not exist");

            drive.AcceptDrive(userContext.UserId, request.DriverArrivingTime);            

            await driveRepository.UpdateItemAsync(drive);
        }
    }
}
