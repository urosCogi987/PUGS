using MediatR;
using TaxiApp.Application.Constants;
using TaxiApp.Domain.Entities;
using TaxiApp.Domain.Entities.Enum;
using TaxiApp.Domain.Repositories;
using TaxiApp.Kernel.Exeptions;

namespace TaxiApp.Application.Users.Commands.SetStatus
{
    internal sealed class SetUserStatusCommandHandler(IUserRepository userRepository) : IRequestHandler<SetUserStatusCommand>
    {
        public async Task Handle(SetUserStatusCommand request, CancellationToken cancellationToken)
        {
            User? user = await userRepository.GetItemByIdAsync(request.Id);
            if (user is null)
                throw new InvalidRequestException(DomainErrors.UserDoesNotExist);

            if (!user.IsEmailVerified && request.UserStatus == UserStatus.Active)
                throw new InvalidRequestException(DomainErrors.UserEmailIsNotVerified);

            user.SetStatus(request.UserStatus);            

            await userRepository.UpdateItemAsync(user);
        }
    }
}
////////////////////////////////////////// RAISE DOMAIN EVENT