using MediatR;
using TaxiApp.Application.Abstractions;
using TaxiApp.Domain.Repositories;
using TaxiApp.Kernel.Exeptions;

namespace TaxiApp.Application.Drive.Commands.Confirm
{
    internal sealed class ConfirmDriveCommandHandler(
        IUserRepository userRepository,
        IUserContext userContext,
        IDriveRepository driveRepository) : IRequestHandler<ConfirmDriveCommand>
    {
        public async Task Handle(ConfirmDriveCommand request, CancellationToken cancellationToken)
        {
            if (!userContext.IsAuthenticated)
            {
                throw new ApplicationException("User is not authenticated");
            }

            if (!await userRepository.CanUserConfirmDrive(userContext.UserId, request.Id))
            {
                throw new ForbiddenOperationException();
            }

            var drive = await driveRepository.GetItemByIdAsync(request.Id);
            if (drive is null)
            {
                throw new ApplicationException("Drive does not exist");
            }

            drive.ConfirmDrive();
            await driveRepository.UpdateItemAsync(drive);
        }
    }
}
