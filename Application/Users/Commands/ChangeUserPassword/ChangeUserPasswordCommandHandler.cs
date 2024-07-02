using Application.Core.Abstractions.Data;
using Application.Core.Abstractions.Messaging;
using Application.Users.Commands.CreateUser;
using Domain.Users;

namespace Application.Users.Commands.ChangeUserPassword;

internal sealed class ChangeUserPasswordCommandHandler : ICommandHandler<ChangeUserPasswordCommand, UserDTO>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ChangeUserPasswordCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<UserDTO> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
    {
        User user = await _userRepository.GetByIdAsync(request.UserId) ?? throw new NullReferenceException();

        _userRepository.Update(user);

        UserDTO userDTO = new UserDTO(user.Id, user.FirstName, user.LastName, user.Email, user.Password);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return userDTO;
    }
}
