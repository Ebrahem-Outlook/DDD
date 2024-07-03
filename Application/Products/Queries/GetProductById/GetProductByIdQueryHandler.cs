using Application.Core.Abstractions.Messaging;
using Application.Products.Commands.CreateProduct;
using Domain.Products;

namespace Application.Products.Queries.GetProductById;

internal sealed class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, ProductDTO>
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        Product product = await _productRepository.GetByIdAsync(request.ProductId, cancellationToken) ?? throw new NullReferenceException();

        return new ProductDTO(product.Id, product.UserId, product.Name, product.Description, product.Price, product.CreatedAt, product.UpdatedAt);
    }
}
