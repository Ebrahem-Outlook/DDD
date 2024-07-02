using FluentValidation;

namespace Application.Users.Commands.ChangeUserPassword;

internal sealed class ChangeUserPasswordCommandValidator : AbstractValidator<ChangeUserPasswordCommand>
{
    public ChangeUserPasswordCommandValidator()
    {
        RuleFor(user => user.UserId).NotNull().NotEmpty();

        RuleFor(user => user.Password).NotNull().NotEmpty();
    }
}
