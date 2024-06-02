﻿namespace TaxiApp.Domain.Entities
{
    public class RefreshToken : BaseEntity
    {
        public RefreshToken(Guid id, Guid userId, string value) : base(id)
        {
            UserId = userId;
            Value = value;
            TokenExpiryTime = DateTime.UtcNow;
        }

        public Guid UserId { get; private set; }
        public string Value { get; private set; }
        public DateTime TokenExpiryTime { get; private set; }


        public User? User { get; private set; }

        public static RefreshToken Create(Guid id, Guid userId,  string value)
            => new RefreshToken(id, userId,  value);
    }
}