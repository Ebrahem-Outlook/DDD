using Application.Core.Abstractions.Messaging;
using Domain.Products;

namespace Application.Products.Queries.GetAllProduct;

internal sealed class GetAllProductsQueryHandler : IQueryHandler<GetAllProductsQuery, List<Product>>
{
    private readonly IProductRepository _productRepository;

    public GetAllProductsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        return await _productRepository.GetAllAsync(cancellationToken) ?? throw new NullReferenceException();
    }
}
