using System.Collections.Generic;
using TransportCompany.Shared.Domain.Events;

namespace TransportCompany.Shared.Domain.Base
{
    public class AggregateRoot : Entity
    {
        private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;

        public void AddDomainEvent(IDomainEvent @event)
        {
            _domainEvents.Add(@event);
        }

        public void ClearEvents()
        {
            _domainEvents.Clear();
        }
    }
}