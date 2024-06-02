using MediatR;
using TaxiApp.Application.Abstractions;
using TaxiApp.Application.Constants;
using TaxiApp.Domain.Entities;
using TaxiApp.Domain.Enums;
using TaxiApp.Domain.Repositories;
using TaxiApp.Kernel.Exeptions;

namespace TaxiApp.Application.Users.RegisterUser
{
    internal sealed class RegisterUserCommandHandler(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher) : IRequestHandler<RegisterUserCommand, Guid>
    {
        public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request);
            var hashedPassword = passwordHasher.Hash(request.Password);

            var user = User.Create(Guid.NewGuid(), request.Username, request.Email, hashedPassword,
                                   request.Name, request.Surname, request.Address, request.DateOfBirth);

            user.SetRole(UserRole.User);

            var persistedUser = await userRepository.AddItemAsync(user);            
            return persistedUser.Id;
        }

        private async Task ValidateRequest(RegisterUserCommand request)
        {
            if (!await userRepository.IsEmailUniqueAsync(request.Email))
                throw new InvalidRequestException(DomainErrors.EmailAlreadyInUse);

            if (!await userRepository.IsUsernameUniqueAsync(request.Username))
                throw new InvalidRequestException(DomainErrors.UsernameAlreadyInUse);
        }
    }
}
