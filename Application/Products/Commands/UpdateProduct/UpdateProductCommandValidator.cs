using FluentValidation;

namespace Application.Products.Commands.UpdateProduct;

internal sealed class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(product => product.ProductId).NotNull().NotEmpty();

        RuleFor(product => product.UserId).NotNull().NotEmpty();

        RuleFor(product => product.Name).NotNull().NotEmpty();

        RuleFor(product => product.Description).NotNull().NotEmpty();

        RuleFor(product => product.Price).NotNull().NotEmpty();
    }
}
