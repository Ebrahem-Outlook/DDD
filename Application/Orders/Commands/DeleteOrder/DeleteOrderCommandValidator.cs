using FluentValidation;

namespace Application.Orders.Commands.DeleteOrder;

internal sealed class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
{
    public DeleteOrderCommandValidator()
    {
        RuleFor(order => order.OrderId).NotNull().NotEmpty();
    }
}
