using MediatR;
using TaxiApp.Application.Abstractions;
using TaxiApp.Application.Constants;
using TaxiApp.Domain.Entities;
using TaxiApp.Domain.Repositories;
using TaxiApp.Kernel.Exeptions;

namespace TaxiApp.Application.Users.Commands.UpdateProfile
{
    internal sealed class UpdateUserProfileCommandHandler(
        IUserRepository userRepository,
        IUserContext userContext) : IRequestHandler<UpdateUserProfileCommand>
    {
        public async Task Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {            
            if (userContext.UserId != request.Id)
                throw new ForbiddenOperationException(DomainErrors.ForbiddenOperation);
                       
            User? user = await userRepository.GetItemByIdAsync(request.Id);
            if (user is null)
                throw new InvalidRequestException(DomainErrors.UserDoesNotExist);

            if (user.Username != request.Username)
            {
                if (!await userRepository.IsUsernameUniqueAsync(request.Username))
                {
                    throw new InvalidRequestException(DomainErrors.UsernameAlreadyInUse);
                }
            }

            user.UpdateProfile(request.Username, request.Name, request.Surname, request.Address, request.DateOfBirth);

            await userRepository.UpdateItemAsync(user);
        }        
    }
}
