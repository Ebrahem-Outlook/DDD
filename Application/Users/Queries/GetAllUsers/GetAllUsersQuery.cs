using Application.Core.Abstractions.Messaging;
using Domain.Users;

namespace Application.Users.Queries.GetAllUsers;

public sealed record GetAllUsersQuery() : IQuery<List<User>>;
