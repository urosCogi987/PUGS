namespace TaxiApp.Domain.DomainEvents
{
    public sealed record UserRegisteredDomainEvent(Guid Id, Guid UserId, Guid TokenId) : DomainEvent(Id);
}
