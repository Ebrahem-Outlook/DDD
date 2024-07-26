using Domain.Core.Events;

namespace Domain.Users.Events;

public sealed record UserEmailChangedDomainEvent(
    Guid UserId,
    string Email) : DomainEvent;
