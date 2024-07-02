using MediatR;

namespace Domain.Core.Abstractions.Events;

public interface IDomainEventHandler<TDomainEvent> : INotificationHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent
{

}
