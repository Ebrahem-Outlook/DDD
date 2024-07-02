using Application.Core.Abstractions.Messaging;
using Application.Users.Commands.CreateUser;

namespace Application.Users.Queries.GetUserById;

public sealed record GetUserByIdQuery(Guid UserId) : IQuery<UserDTO>;
