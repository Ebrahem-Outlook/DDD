using Domain.Core.Abstractions.Events;

namespace Domain.Users.Events;

public sealed record UserEmailChangedDomainEvent(
    Guid UserId,
    string Email) : IDomainEvent;
