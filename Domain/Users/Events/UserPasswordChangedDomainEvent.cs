using Domain.Core.Abstractions.Events;

namespace Domain.Users.Events;

public sealed record UserPasswordChangedDomainEvent(
    Guid UserId,
    string Password) : IDomainEvent;
