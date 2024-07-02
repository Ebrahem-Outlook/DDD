using Application.Core.Abstractions.Messaging;
using Application.Users.Commands.CreateUser;

namespace Application.Users.Commands.ChangeUserName;

public sealed record ChangeUserNameCommand(
    Guid UserId,
    string FirstName,
    string LastName) : ICommand<UserDTO>;
