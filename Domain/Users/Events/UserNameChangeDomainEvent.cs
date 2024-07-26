using Domain.Core.Events;

namespace Domain.Users.Events;

public sealed record UserNameChangedDomainEvent(
    Guid UserId,
    string Firstname,
    string LastName) : DomainEvent;
