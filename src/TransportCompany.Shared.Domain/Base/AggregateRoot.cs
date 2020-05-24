using System.Collections.Generic;

namespace TransportCompany.Shared.Domain.Base
{
    public class AggregateRoot : Entity
    {
        private readonly List<object> _domainEvents = new List<object>();
        public IReadOnlyList<object> DomainEvents => _domainEvents;

        public void AddDomainEvent<TEvent>(TEvent @event) where TEvent : class
        {
            _domainEvents.Add(@event);
        }
    }
}