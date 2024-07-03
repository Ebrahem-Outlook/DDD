using FluentValidation;

namespace Application.Products.Commands.DeleteProduct;

internal sealed class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(product => product.ProductId).NotNull().NotEmpty();
    }
}
