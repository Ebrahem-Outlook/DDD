namespace API.Contracts.User;

public sealed record ChangeUserPasswordRequest(
    Guid UserId,
    string Password);
