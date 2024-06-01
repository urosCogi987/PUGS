using MediatR;
using TaxiApp.Domain.Entities;
using TaxiApp.Domain.Enums;
using TaxiApp.Domain.Repositories;

namespace TaxiApp.Application.Users.RegisterUser
{
    internal sealed class RegisterUserCommandHandler(IUserRepository userRepository) : IRequestHandler<RegisterUserCommand, Guid>
    {
        public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (!await userRepository.IsEmailUniqueAsync(request.Email))
                throw new Exception();

            if (!await userRepository.IsUsernameUniqueAsync(request.Username))
                throw new Exception();

            var user = User.Create(Guid.NewGuid(), request.Username, request.Email, request.Password,
                                   request.Name, request.Surname, request.Address, request.DateOfBirth);

            user.SetRole(UserRole.User);

            var persistedUser = await userRepository.AddItemAsync(user);
            if (persistedUser is null)
                throw new Exception("To do");

            return persistedUser.Id;
        }
    }
}
