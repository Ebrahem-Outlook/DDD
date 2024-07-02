namespace Application.Users.Commands.CreateUser;

public sealed record UserDTO(
    Guid UserId,
    string FirstName,
    string LastName,
    string Email,
    string Password);


