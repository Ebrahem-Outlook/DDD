using Domain.Core.Abstractions.Events;

namespace Domain.Products.Events;

public sealed record ProductCreatedDomainEvent(
    Guid ProductId,
    string Name,
    string Description,
    decimal Price,
    DateTime CreatedAt) : IDomainEvent;
