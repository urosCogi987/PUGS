﻿using TaxiApp.Domain.DomainEvents;

namespace TaxiApp.Domain.Entities
{
    public abstract class BaseEntity
    {
        private readonly List<IDomainEvent> _domainEvents = new();

        protected BaseEntity(Guid id) => Id = id;

        public Guid Id { get; private set; }

        public IReadOnlyCollection<IDomainEvent> GetDomainEvents() => _domainEvents.ToList();

        public void ClearDomainEvents() => _domainEvents.Clear();

        protected void RaiseDomainEvent(IDomainEvent domainEvent) =>
            _domainEvents.Add(domainEvent);        
    }
}
