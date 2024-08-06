﻿using MediatR;
using TaxiApp.Application.Abstractions;
using TaxiApp.Application.Constants;
using TaxiApp.Domain.Repositories;
using TaxiApp.Kernel.Exeptions;
using DriveEntity = TaxiApp.Domain.Entities.Drive;

namespace TaxiApp.Application.Drive.Queries.GetDriveDetails
{
    internal sealed class GetDriveDetailsQueryHandler(
        IDriveRepository driveRepository,
        IUserContext userContext,
        IUserRepository userRepository) : IRequestHandler<GetDriveDetailsQuery, DriveEntity>
    {
        public async Task<DriveEntity> Handle(GetDriveDetailsQuery request, CancellationToken cancellationToken)
        {
            if (!userContext.IsAuthenticated)
            {
                throw new ApplicationException("User not authenticated.");
            }                

            var drive = await driveRepository.GetDriveWithUsers(request.Id);
            if (drive is null)
            {
                throw new ApplicationException("Drive does not exist");
            }

            if (!CanUserViewDriveDetails(drive, userContext.UserId, await userRepository.IsUserAdmin(userContext.UserId)))
            {
                throw new ForbiddenOperationException(DomainErrors.ForbiddenOperation);
            }
            
            return drive;
        }

        private bool CanUserViewDriveDetails(DriveEntity drive, Guid userId, bool isAdmin)
        {            
            if ((drive.UserId != userContext.UserId && drive.DriverId != userContext.UserId) && !isAdmin)
            {
                return false;
            }

            return true;
        }
    }
}
