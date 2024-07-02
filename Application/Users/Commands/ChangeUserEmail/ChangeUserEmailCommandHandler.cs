using Application.Core.Abstractions.Data;
using Application.Core.Abstractions.Messaging;
using Application.Users.Commands.CreateUser;
using Domain.Users;

namespace Application.Users.Commands.ChangeUserEmail;

internal sealed class ChangeUserEmailCommandHandler : ICommandHandler<ChangeUserEmailCommand, UserDTO>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ChangeUserEmailCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<UserDTO> Handle(ChangeUserEmailCommand request, CancellationToken cancellationToken)
    {
        User user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken) ?? throw new NullReferenceException();

        user.ChangeEmail(request.Email);

        _userRepository.Update(user);

        UserDTO userDTO = new UserDTO(user.Id, user.FirstName, user.LastName, user.Email, user.Password);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return userDTO;
    }
}
