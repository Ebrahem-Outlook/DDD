using FluentValidation;

namespace Application.Users.Commands.DeleteUser;

internal sealed class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(user => user.UserId).NotNull().NotEmpty();
    }
}
