using TaxiApp.Application.Dtos;

namespace TaxiApp.WebApi.Models.User
{
    public sealed class LoginUserResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public Guid UserId { get; set; }

        public LoginUserResponse(TokensDto tokensDto)
        {
            AccessToken = tokensDto.AccessToken;
            RefreshToken = tokensDto.RefreshToken;
            UserId = tokensDto.UserId;
        }
    }
}
