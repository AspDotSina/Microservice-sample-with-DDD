using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Framework
{
    public class AggregateRoot : Entity
    {
        public int Version { get; private set; }

        private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
        protected AggregateRoot()
        {

        }


        protected void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
        protected void RemoveDomainEvent(IDomainEvent domainEvent) => _domainEvents.Remove(domainEvent);
        protected void ClearDomainEvent(IDomainEvent domainEvent) => _domainEvents.Clear();
        public IReadOnlyCollection<IDomainEvent> domainEvents => _domainEvents.AsReadOnly();

        public AggregateRoot(IEnumerable<IDomainEvent> events)
        {
            if (events == null)
            {
                return;
            }
            foreach (var e in events)
            {
                Mutate(e);
                Version++;


            }
        }


        protected void Apply(IEnumerable<IDomainEvent> events)
        {
            foreach (var e in events)
            {
                Apply(e);
            }
        }

        protected void Apply(IDomainEvent events)
        {
            Mutate(events);
            AddDomainEvent(events);
        }

        private void Mutate(IDomainEvent domainEvent) => ((dynamic)this).On((dynamic)domainEvent);
    }
}
