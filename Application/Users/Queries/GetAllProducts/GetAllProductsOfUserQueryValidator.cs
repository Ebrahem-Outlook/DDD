using FluentValidation;

namespace Application.Users.Queries.GetAllProducts;

internal sealed class GetAllProductsOfUserQueryValidator : AbstractValidator<GetAllProductsOfUserQuery>
{
    public GetAllProductsOfUserQueryValidator()
    {
        RuleFor(product => product.UserId).NotNull().NotEmpty();
    }
}
