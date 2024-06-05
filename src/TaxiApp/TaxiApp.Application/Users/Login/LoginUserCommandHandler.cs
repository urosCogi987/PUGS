using MediatR;
using TaxiApp.Application.Abstractions;
using TaxiApp.Application.Constants;
using TaxiApp.Application.Dtos;
using TaxiApp.Domain.Entities;
using TaxiApp.Domain.Repositories;
using TaxiApp.Kernel.Exeptions;

namespace TaxiApp.Application.Users.Login
{
    internal sealed class LoginUserCommandHandler(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IJwtProvider jwtProvider,
        IRefreshTokenRepository refreshTokenRepository) : IRequestHandler<LoginUserCommand, TokensDto>
    {
        public async Task<TokensDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
                User? user = await userRepository.Find(x => x.Email == request.Email);
            if (user is null)
                throw new InvalidRequestException(DomainErrors.InvalidCredentials);

            bool verified =  passwordHasher.VerifyPassword(user.Password, request.Password);
            if (!verified)
                throw new InvalidRequestException(DomainErrors.InvalidCredentials);

            var tokensDto = TokensDto.Create(jwtProvider.GenerateAccessToken(user), jwtProvider.GenerateEmptyToken());            
            await refreshTokenRepository.AddItemAsync(RefreshToken.Create(Guid.NewGuid(), user.Id, tokensDto.RefreshToken));

            return tokensDto;
        }
    }
}
