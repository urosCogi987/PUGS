using MediatR;
using TaxiApp.Application.Abstractions;
using TaxiApp.Application.Dtos;
using TaxiApp.Domain.Entities.Enum;
using DriveEntity = TaxiApp.Domain.Entities.Drive;

namespace TaxiApp.Application.Drive.Commands
{
    internal sealed class CreateDriveCommandHandler(
        IDriveCalculator driveCalculator) : IRequestHandler<CreateDriveCommand, CreatedDriveDto>
    {
        public async Task<CreatedDriveDto> Handle(CreateDriveCommand request, CancellationToken cancellationToken)
        {
            (double estimatedPrice, int estimatedTime) = driveCalculator.CalculateDrive(request.FromLatitude, request.FromLongitude, request.ToLatitude, request.ToLongitude);

            var drive = DriveEntity.Create(Guid.NewGuid(), request.FromAddress, request.FromLatitude, request.FromLongitude,
                                           request.ToAddress, request.ToLatitude, request.ToLongitude, DriveStatus.Created);


            

            throw new Exception();
        }
    }
}
