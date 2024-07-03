namespace API.Contracts.User;

public sealed record ChangeUserNameRequest(
    Guid UserId, 
    string FirstName,
    string LastName);
