using Application.Core.Abstractions.Messaging;
using Application.Users.Commands.CreateUser;

namespace Application.Users.Commands.ChangeUserEmail;

public sealed record ChangeUserEmailCommand(
    Guid UserId,
    string Email) : ICommand<UserDTO>;
