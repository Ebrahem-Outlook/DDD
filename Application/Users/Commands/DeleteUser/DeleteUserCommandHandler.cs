using Application.Core.Abstractions.Data;
using Application.Core.Abstractions.Messaging;
using Application.Users.Commands.CreateUser;
using Domain.Users;

namespace Application.Users.Commands.DeleteUser;

internal sealed class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand, UserDTO>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<UserDTO> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        User user = await _userRepository.GetByIdAsync(request.UserId) ?? throw new NullReferenceException();

        _userRepository.Delete(user);

        UserDTO userDTO = new UserDTO(user.Id, user.FirstName, user.LastName, user.Email, user.Password);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return userDTO;
    }
}
