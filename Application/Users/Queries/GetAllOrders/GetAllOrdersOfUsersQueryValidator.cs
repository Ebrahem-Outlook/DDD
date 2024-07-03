using FluentValidation;

namespace Application.Users.Queries.GetAllOrders;

internal sealed class GetAllOrdersOfUsersQueryValidator : AbstractValidator<GetAllOrdersOfUserQuery>
{
    public GetAllOrdersOfUsersQueryValidator()
    {
        RuleFor(order => order.UserId).NotNull().NotEmpty();
    }
}