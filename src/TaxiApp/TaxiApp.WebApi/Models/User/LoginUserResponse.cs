using TaxiApp.Application.Users.Dtos;

namespace TaxiApp.WebApi.Models.User
{
    public sealed class LoginUserResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }        

        public LoginUserResponse(TokensDto tokensDto)
        {
            AccessToken = tokensDto.AccessToken;
            RefreshToken = tokensDto.RefreshToken;            
        }
    }
}
