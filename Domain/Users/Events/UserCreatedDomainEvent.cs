using Domain.Core.Events;

namespace Domain.Users.Events;

public sealed record UserCreatedDomainEvent(
    Guid UserId,
    string FirstName, 
    string LastName,
    string Email, 
    string Passwor) : DomainEvent;
