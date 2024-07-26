using Domain.Core.Events;

namespace Domain.Users.Events;

public sealed record UserPasswordChangedDomainEvent(
    Guid UserId,
    string Password) : DomainEvent;
