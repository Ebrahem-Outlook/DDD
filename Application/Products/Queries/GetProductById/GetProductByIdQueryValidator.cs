using FluentValidation;

namespace Application.Products.Queries.GetProductById;

internal sealed class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
{
    public GetProductByIdQueryValidator()
    {
        RuleFor(user => user.ProductId).NotNull().NotEmpty();
    }
}
