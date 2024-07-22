namespace TaxiApp.Application.Dtos
{
    public sealed class TokensDto
    {
        private TokensDto(string accessToken, string refreshToken, Guid userId)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            UserId = userId;
        }

        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public Guid UserId { get; set; }

        public static TokensDto Create(string accessToken, string refreshToken, Guid userId)
            => new TokensDto(accessToken, refreshToken, userId);
    }
}
