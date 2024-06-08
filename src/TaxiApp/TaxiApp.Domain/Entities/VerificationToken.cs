using TaxiApp.Domain.DomainEvents;

namespace TaxiApp.Domain.Entities
{
    public sealed class VerificationToken : BaseEntity
    {
        private VerificationToken(Guid id, Guid userId, string value, DateTime tokenExpiryTime) : base(id)
        {
            UserId = userId;
            Value = value;
            TokenExpiryTime = tokenExpiryTime;
        }
        
        public Guid UserId { get; private set; }
        public string Value { get; private set; }
        public DateTime TokenExpiryTime { get; private set; }


        public User? User { get; private set; }

        public static VerificationToken Create(Guid id, Guid userId, string value, DateTime tokenExpiryTime)
        {
            var verificationToken = new VerificationToken(id, userId, value, tokenExpiryTime);
            verificationToken.RaiseDomainEvent(new UserRegisteredDomainEvent(Guid.NewGuid(), userId, id));
            return verificationToken;
        }
    }
}
