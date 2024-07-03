using FluentValidation;

namespace Application.Orders.Commands.CreateOrder;

internal sealed class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(order => order.Products).NotNull().NotEmpty();
    }
}