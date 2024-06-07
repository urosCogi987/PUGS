using MediatR;
using TaxiApp.Application.Abstractions;
using TaxiApp.Application.Constants;
using TaxiApp.Application.Dtos;
using TaxiApp.Domain.Entities;
using TaxiApp.Domain.Repositories;
using TaxiApp.Kernel.Exeptions;

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
            if (!userContext.IsAuthenticated)
                throw new ApplicationException("User not authenticated.");
         
            User? user = await userRepository.GetUserWithRefreshTokens(userContext.UserId);
            if (user is null)
                throw new ApplicationException("User does not exist.");

            RefreshToken? refreshToken = user?.RefreshTokens?.FirstOrDefault(x => x.Value == request.RefreshToken);
            if (refreshToken is null)            
                throw new InvalidRequestException(DomainErrors.InvalidRefreshToken);
            
            if (refreshToken.IsUsed)
            {
                await refreshTokenRepository.DeleteItemsRangeAsync(user!.RefreshTokens!);
            }
            else
            {
                refreshToken.UseToken();
                await refreshTokenRepository.UpdateItemAsync(refreshToken);
            }

            var tokensDto = TokensDto.Create(jwtProvider.GenerateAccessToken(user!), jwtProvider.GenerateEmptyToken());
            await refreshTokenRepository.AddItemAsync(RefreshToken.Create(Guid.NewGuid(), user!.Id, tokensDto.RefreshToken));

            return tokensDto;
        }
    }
}
