namespace API.Contracts.User;

public sealed record CreateUserRequest(
    string FirstName, 
    string LastName,
    string Email,
    string Password);
