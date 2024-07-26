using Domain.Core.Events;

namespace Domain.Products.Events;

public sealed record ProductCreatedDomainEvent(
    Guid ProductId,
    string Name,
    string Description,
    decimal Price,
    DateTime CreatedAt) : DomainEvent;
