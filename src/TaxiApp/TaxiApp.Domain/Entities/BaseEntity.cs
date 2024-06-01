﻿namespace TaxiApp.Domain.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity(Guid id) => Id = id;

        public Guid Id { get; private set; }
    }
}
