using MediatR;
using TaxiApp.Application.Abstractions;
using TaxiApp.Application.Dtos;
using TaxiApp.Domain.Entities;
using TaxiApp.Domain.Repositories;

namespace TaxiApp.Application.Users.Refresh
{
    internal sealed class RefreshTokenCommandHandler(
        IRefreshTokenRepository refreshTokenRepository, 
        IUserContext userContext,
        IJwtProvider jwtProvider,
        IUserRepository userRepository) : IRequestHandler<RefreshTokenCommand, TokensDto>
    {
        public async Task<TokensDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            // ima li smisla? razmisli sta treba sve u slucaju refresh-a
            if (!userContext.IsAuthenticated)
                throw new ApplicationException("User not authenticated.");

            User user = await userRepository.GetItemByIdAsync(userContext.UserId);

            RefreshToken refreshToken = 
                await refreshTokenRepository.AddItemAsync(RefreshToken.Create(Guid.NewGuid(), user.Id, jwtProvider.GenerateEmptyToken()));

            return TokensDto.Create(refreshToken.Value, jwtProvider.GenerateAccessToken(user));
        }
    }
}
