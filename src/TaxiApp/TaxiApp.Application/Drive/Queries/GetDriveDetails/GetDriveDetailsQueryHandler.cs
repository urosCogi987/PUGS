using MediatR;
using TaxiApp.Application.Abstractions;
using TaxiApp.Application.Constants;
using TaxiApp.Domain.Entities;
using TaxiApp.Domain.Entities.Enum;
using TaxiApp.Domain.Repositories;
using TaxiApp.Kernel.Constants;
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

            var user = await userRepository.GetUserWithRoles(userContext.UserId);
            if (user is null)
            {
                throw new ApplicationException("User does not exist");
            }

            if (!CanUserViewDriveDetails(drive, user))
            {
                throw new ForbiddenOperationException(DomainErrors.ForbiddenOperation);
            }
            
            return drive;
        }

        private bool CanUserViewDriveDetails(DriveEntity drive, User user)
        {            
            if (user.Roles.Any(x => x.Name == RoleNames.User) && drive.UserId == user.Id)
            {
                return true;
            }

            if (user.Roles.Any(x => x.Name == RoleNames.Driver) 
                && (drive.DriverId == user.Id || drive.Status == DriveStatus.UserConfirmed))
            {
                return true;
            }     
            
            if (user.Roles.Any(x => x.Name == RoleNames.Admin))
            {
                return true;
            }

            return false;
        }
    }
}
