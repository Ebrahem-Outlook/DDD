using Application.Core.Abstractions.Data;
using Application.Core.Abstractions.Messaging;
using Domain.Users;

namespace Application.Users.Queries.GetAllUsers;

internal sealed record GetAllUsersQueryHandler : IQueryHandler<GetAllUsersQuery, List<User>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUsersQueryHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
    }

    public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetAllAsync(cancellationToken) ?? throw new NullReferenceException();
    }
}
