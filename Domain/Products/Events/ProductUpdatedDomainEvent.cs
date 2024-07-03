using Domain.Core.Abstractions.Events;

namespace Domain.Products.Events;

public sealed record ProductUpdatedDomainEvent(
    Guid ProductId,
    string Name,
    string Description,
    decimal Price,
    DateTime CreatedAt,
    DateTime UpdatedAt) : IDomainEvent;
