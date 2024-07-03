using Domain.Products;
using Application.Core.Abstractions.Messaging;
using Application.Core.Abstractions.Data;

namespace Application.Products.Commands.CreateProduct;

internal sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, ProductDTO>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ProductDTO> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        Product product = Product.Create(request.UserId, request.Name, request.Description, request.Price);

        await _productRepository.AddAsync(product, cancellationToken);

        ProductDTO productDTO = new ProductDTO(product.Id, product.UserId, product.Name, product.Description, product.Price, product.CreatedAt, product.UpdatedAt);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return productDTO;
    }
}
