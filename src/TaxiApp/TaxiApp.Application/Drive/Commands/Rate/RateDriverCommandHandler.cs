using MediatR;
using TaxiApp.Application.Abstractions;
using TaxiApp.Domain.Entities.Enum;
using TaxiApp.Domain.Repositories;
using TaxiApp.Kernel.Exeptions;

namespace TaxiApp.Application.Drive.Commands.RateDriver
{
    internal sealed class RateDriverCommandHandler(
        IUserContext userContext,
        IDriveRepository driveRepository) : IRequestHandler<RateDriverCommand>
    {
        public async Task Handle(RateDriverCommand request, CancellationToken cancellationToken)
        {
            if (!userContext.IsAuthenticated)
            {
                throw new ApplicationException("User is not authenticated");
            }

            var drive = await driveRepository.GetDriveWithUsers(request.Id);
            if (drive == null)
            {
                throw new ApplicationException("Drive doesnt exist.");
            }            

            if (drive.UserId != userContext.UserId)
            {
                throw new ForbiddenOperationException("This operation is forbidden.");
            }

            if (drive.Status != DriveStatus.Finished)
            {
                throw new ForbiddenOperationException("You can rate the driver once the drive is finished.");
            }

            drive.RateDriver(request.Rating);
            await driveRepository.UpdateItemAsync(drive);
        }
    }
}
