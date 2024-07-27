using Application.Core.Abstractions.Data;
using Application.Core.Abstractions.Messaging;
using Domain.Users;
using Microsoft.Extensions.Logging;

namespace Application.Users.Commands.CreateUser;

internal sealed class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, UserDTO>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CreateUserCommandHandler> _logger;

    public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, ILogger<CreateUserCommandHandler> logger)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<UserDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {

        User user = User.Create(request.FirstName, request.LastName, request.Email, request.Password);

        await _userRepository.AddAsync(user, cancellationToken);

        UserDTO userDTO = new UserDTO(user.Id, user.FirstName, user.LastName, user.Email, user.Password);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return userDTO;
    }
}
