using MediatR;
using TaxiApp.Application.Abstractions;
using TaxiApp.Application.Constants;
using TaxiApp.Domain.Entities;
using TaxiApp.Domain.Repositories;
using TaxiApp.Kernel.Exeptions;

namespace TaxiApp.Application.Users.Register
{
    internal sealed class RegisterUserCommandHandler(
        IUserRepository userRepository,
        IRoleRepository roleRepository,
        IUserRoleRepository userRoleRepository,        
        IPasswordHasher passwordHasher) : IRequestHandler<RegisterUserCommand, Guid>
    {
        public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request);
            var role = await ReturnRoleIfEists(request.RoleName);
            var hashedPassword = passwordHasher.Hash(request.Password);
            
            var user = User.Create(Guid.NewGuid(), request.Username, request.Email,
                                   hashedPassword, request.Name, request.Surname, 
                                   request.Address, request.DateOfBirth);
                      
            var persistedUser = await userRepository.AddItemAsync(user);
            await userRoleRepository.AddItemAsync(UserRole.Create(persistedUser.Id, role.Id));

            return persistedUser.Id;
        }

        private async Task ValidateRequest(RegisterUserCommand request)
        {
            if (!await userRepository.IsEmailUniqueAsync(request.Email))
                throw new InvalidRequestException(DomainErrors.EmailAlreadyInUse);

            if (!await userRepository.IsUsernameUniqueAsync(request.Username))
                throw new InvalidRequestException(DomainErrors.UsernameAlreadyInUse);
        }

        private async Task<Role> ReturnRoleIfEists(string roleName)
        {
            var role = await roleRepository.Find(x => x.Name == roleName);
            if (role is null)
                throw new InvalidRequestException(DomainErrors.InvalidRoleName);

            return role;
        }
    }
}
