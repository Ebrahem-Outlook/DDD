using FluentValidation;

namespace Application.Users.Commands.ChangeUserEmail;

internal sealed class ChangeUserEmailCommandValidator : AbstractValidator<ChangeUserEmailCommand>
{
    public ChangeUserEmailCommandValidator()
    {
        RuleFor(user => user.UserId).NotEmpty().NotNull();

        RuleFor(user => user.Email).NotEmpty().NotNull();
    }
}
