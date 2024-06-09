using MediatR;
using TaxiApp.Application.Abstractions;
using TaxiApp.Application.Constants;
using TaxiApp.Domain.Entities;
using TaxiApp.Domain.Repositories;
using TaxiApp.Kernel.Exeptions;

namespace TaxiApp.Application.Users.Commands.ChangePassword
{
    internal sealed class ChangePasswordCommandHandler(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher) : IRequestHandler<ChangePasswordCommand>
    {
        public async Task Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {               
            User? user = await userRepository.GetItemByIdAsync(request.Id);
            if (user is null)
                throw new ApplicationException(DomainErrors.UserDoesNotExist);

            if (!passwordHasher.VerifyPassword(user.Password, request.OldPassword))
                throw new InvalidRequestException(DomainErrors.IncorrectPassowrd);

            user.ChangePassword(passwordHasher.Hash(request.NewPassword));

            await userRepository.UpdateItemAsync(user);
        }
    }
}
