using MediatR;
using Microsoft.Extensions.Configuration;
using TaxiApp.Application.Abstractions;
using TaxiApp.Application.Constants;
using TaxiApp.Application.Dtos;
using TaxiApp.Domain.Entities;
using TaxiApp.Domain.Repositories;
using TaxiApp.Kernel.Exeptions;

namespace TaxiApp.Application.Users.Commands.Refresh
{
    internal sealed class RefreshTokenCommandHandler(
        IRefreshTokenRepository refreshTokenRepository,        
        IJwtProvider jwtProvider,
        IUserRepository userRepository,
        IConfiguration configuration) : IRequestHandler<RefreshTokenCommand, TokensDto>
    {
        public async Task<TokensDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var refreshToken = await refreshTokenRepository.Find(x => x.Value == request.RefreshToken);
            if (refreshToken is null)
            {
                throw new InvalidRequestException(DomainErrors.InvalidRefreshToken);
            }

            var user = await userRepository.GetUserWithRefreshTokens(refreshToken.UserId);
            if (user is null)
            {
                throw new InvalidRequestException(DomainErrors.InvalidRefreshToken);
            }

            if (refreshToken.IsUsed)
            {
                await refreshTokenRepository.DeleteItemsRangeAsync(user!.RefreshTokens!);
            }
            else if (refreshToken.TokenExpiryTime < DateTime.UtcNow)
            {
                throw new InvalidRequestException(DomainErrors.RefreshTokenExpired);
            }
            else
            {
                refreshToken.UseToken();
                await refreshTokenRepository.UpdateItemAsync(refreshToken);
            }            

            var tokensDto = TokensDto.Create(jwtProvider.GenerateAccessToken(user!), jwtProvider.GenerateEmptyToken(), user!.Id);
            await refreshTokenRepository.AddItemAsync(RefreshToken.Create(
                Guid.NewGuid(), 
                user!.Id, 
                tokensDto.RefreshToken,
                DateTime.UtcNow.AddMinutes(int.Parse(configuration["Tokens:VerificationTokenExpiryTimeInMinutes"]!))));

            return tokensDto;
        }
    }
}
