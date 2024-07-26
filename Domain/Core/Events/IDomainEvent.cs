using MediatR;

namespace Domain.Core.Events;

public interface IDomainEvent : INotification
{
    Guid Id { get; }

    DateTime OcurresOn { get; }
}
