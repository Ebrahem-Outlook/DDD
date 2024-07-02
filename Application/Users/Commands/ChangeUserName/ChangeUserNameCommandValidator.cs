using FluentValidation;

namespace Application.Users.Commands.ChangeUserName;

internal sealed class ChangeUserNameCommandValidator : AbstractValidator<ChangeUserNameCommand>
{
    public ChangeUserNameCommandValidator()
    {
        RuleFor(user => user.UserId).NotNull().NotEmpty();

        RuleFor(user => user.FirstName).NotNull().NotEmpty();

        RuleFor(user => user.LastName).NotNull().NotEmpty();
    }
}
