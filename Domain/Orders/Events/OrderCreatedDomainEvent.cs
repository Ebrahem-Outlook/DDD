using Domain.Core.Events;

namespace Domain.Orders.Events;

public sealed record OrderCreatedDomainEvent(
    Guid UserId,
    Guid OrderId,
    decimal TotalPrice,
    DateTime CreatedAt) : DomainEvent;
