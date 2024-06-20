namespace TaxiApp.Domain.DomainEvents
{
    public sealed record DriveAcceptedDomainEvent(Guid Id, Guid UserId, Guid DriverId) : DomainEvent(Id);
}
