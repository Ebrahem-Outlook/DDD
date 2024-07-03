namespace API.Contracts.User;

public sealed record ChangeUserEmailRequest(
    Guid UserId,
    string Email);
