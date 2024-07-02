using FluentValidation;

namespace Application.Users.Commands.CreateUser;

internal sealed class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(user => user.FirstName).NotNull().NotEmpty();

        RuleFor(user => user.LastName).NotNull().NotEmpty();

        RuleFor(user => user.Email).NotNull().NotEmpty();

        RuleFor(user => user.Password).NotNull().NotEmpty();
    }
}
