namespace TaxiApp.Domain.DomainEvents
{
    public sealed record UserVerifiedEmailDomainEvent(Guid Id, Guid UserId) : DomainEvent(Id);    
}
