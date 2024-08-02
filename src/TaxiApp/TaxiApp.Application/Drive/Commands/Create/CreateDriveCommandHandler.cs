using MediatR;
using TaxiApp.Application.Abstractions;
using TaxiApp.Application.Drive.Dtos;
using TaxiApp.Domain.Entities.Enum;
using TaxiApp.Domain.Repositories;
using DriveEntity = TaxiApp.Domain.Entities.Drive;

namespace TaxiApp.Application.Drive.Commands.Create
{
    internal sealed class CreateDriveCommandHandler(
        IDriveCalculator driveCalculator,
        IUserContext userContext,
        IDriveRepository driveRepository) : IRequestHandler<CreateDriveCommand, CreatedDriveDto>
    {
        public async Task<CreatedDriveDto> Handle(CreateDriveCommand request, CancellationToken cancellationToken)
        {
            if (!userContext.IsAuthenticated)
            {
                throw new ApplicationException("User is not authenticated");
            }

            (int estimatedDriverArrivalTime, double estimatedPrice) = driveCalculator.CalculateDriveV2(request.Distance);            

            var drive = DriveEntity.Create(
                Guid.NewGuid(), 
                userContext.UserId, 
                request.FromAddress, 
                request.ToAddress, 
                DriveStatus.Created, 
                request.Distance, 
                request.EstimatedDuration, 
                estimatedPrice, 
                estimatedDriverArrivalTime);

            await driveRepository.AddItemAsync(drive);

            return CreatedDriveDto.Create(drive.Id, estimatedDriverArrivalTime, estimatedPrice);
        }
    }
}
