using MediatR;

namespace TaxiApp.Domain.DomainEvents
{
    public interface IDomainEvent : INotification
    {
        public Guid Id { get; init; }
    }
}
