using Application.Core.Abstractions.Data;
using Application.Core.Abstractions.Messaging;
using Application.Products.Commands.CreateProduct;
using Domain.Products;

namespace Application.Products.Commands.DeleteProduct;

internal sealed class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand, ProductDTO>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ProductDTO> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        Product product = await _productRepository.GetByIdAsync(request.ProductId, cancellationToken) ?? throw new NullReferenceException();

        _productRepository.Delete(product);

        ProductDTO productDTO = new ProductDTO(product.Id, product.UserId, product.Name, product.Description, product.Price, product.CreatedAt, product.UpdatedAt);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return productDTO;
    }
}
