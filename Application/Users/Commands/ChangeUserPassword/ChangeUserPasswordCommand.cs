using Application.Core.Abstractions.Messaging;
using Application.Users.Commands.CreateUser;

namespace Application.Users.Commands.ChangeUserPassword;

public sealed record ChangeUserPasswordCommand(
    Guid UserId,
    string Password) : ICommand<UserDTO>;
