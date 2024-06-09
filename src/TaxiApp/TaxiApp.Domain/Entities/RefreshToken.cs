namespace TaxiApp.Domain.Entities
{
    public class RefreshToken : BaseEntity
    {
        private RefreshToken(Guid id, Guid userId, string value, DateTime tokenExpiryTime) : base(id)
        {
            UserId = userId;
            Value = value;
            TokenExpiryTime = tokenExpiryTime;
            IsUsed = false;
        }

        public Guid UserId { get; private set; }
        public string Value { get; private set; }
        public bool IsUsed { get; private set; }
        public DateTime TokenExpiryTime { get; private set; }


        public User? User { get; private set; }

        public void UseToken()
            => IsUsed = true;

        public static RefreshToken Create(Guid id, Guid userId,  string value, DateTime tokenExpiryTime)
            => new RefreshToken(id, userId,  value, tokenExpiryTime);
    }
}
