namespace TaxiApp.Application.Users.Dtos
{
    public sealed class TokensDto
    {
        private TokensDto(string accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }

        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public static TokensDto Create(string accessToken, string refreshToken)
            => new TokensDto(accessToken, refreshToken);
    }
}
