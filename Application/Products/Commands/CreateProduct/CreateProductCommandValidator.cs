using FluentValidation;

namespace Application.Products.Commands.CreateProduct;

internal sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(product => product.UserId).NotEmpty().NotNull();

        RuleFor(product => product.Name).NotEmpty().NotNull();

        RuleFor(product => product.Description).NotEmpty().NotNull();

        RuleFor(product => product.Price).NotEmpty().NotNull();
    }
}
