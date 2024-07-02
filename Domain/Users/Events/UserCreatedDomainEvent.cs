using Domain.Core.Abstractions.Events;

namespace Domain.Users.Events;

public sealed record UserCreatedDomainEvent(
    Guid UserId,
    string FirstName, 
    string LastName,
    string Email, 
    string Passwor) : IDomainEvent;
