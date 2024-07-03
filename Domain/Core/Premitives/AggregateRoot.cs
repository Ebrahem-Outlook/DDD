using Domain.Core.Abstractions.Events;

namespace Domain.Core.Premitives;

public abstract class AggregateRoot : Entity
{
    protected AggregateRoot(Guid id) : base(id) { }

    protected AggregateRoot() : base() { }

    private List<IDomainEvent> domainEvents = new List<IDomainEvent>();

    public IReadOnlyCollection<IDomainEvent> DomainEvents => domainEvents.AsReadOnly();

    public void AddDomainEvent(IDomainEvent @event) => domainEvents.Add(@event);

    public void Clear() => domainEvents.Clear();
}
