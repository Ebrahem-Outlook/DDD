using Application.Core.Abstractions.Messaging;
using Application.Users.Commands.CreateUser;
using Domain.Users;

namespace Application.Users.Queries.GetUserById;

internal sealed class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserDTO>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        User user = await _userRepository.GetByIdAsync(request.UserId) ?? throw new NullReferenceException();

        UserDTO userDTO = new UserDTO(user.Id, user.FirstName, user.LastName, user.Email, user.Password);

        return userDTO;
    }
}
