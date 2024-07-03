using FluentValidation;

namespace Application.Orders.Queries.GetOrderById;

internal sealed class GetOrderByIdQueryValidator : AbstractValidator<GetOrderByIdQuery>
{
    public GetOrderByIdQueryValidator()
    {
        RuleFor(order => order.OrderId).NotNull().NotEmpty();
    }
}
