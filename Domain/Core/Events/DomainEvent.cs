namespace Domain.Core.Events;

public abstract record DomainEvent : IDomainEvent
{
    protected DomainEvent() : this(Guid.NewGuid(), DateTime.UtcNow) 
    {
    }

    private DomainEvent(Guid id, DateTime ocurresOn)
    {
        Id = id;
        OcurresOn = ocurresOn;
    }

    public Guid Id { get; }

    public DateTime OcurresOn { get; }
}
