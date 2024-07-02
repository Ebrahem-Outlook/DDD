using Application.Core.Abstractions.Messaging;
using Application.Users.Commands.CreateUser;

namespace Application.Users.Commands.DeleteUser;

public sealed record DeleteUserCommand(Guid UserId) : ICommand<UserDTO>;
