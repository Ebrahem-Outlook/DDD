using Application.Core.Abstractions.Data;
using Application.Core.Abstractions.Messaging;
using Application.Products.Commands.CreateProduct;
using Domain.Products;

namespace Application.Products.Commands.UpdateProduct;

internal sealed class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, ProductDTO>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ProductDTO> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        Product product = await _productRepository.GetByIdAsync(request.ProductId, cancellationToken)
            ?? throw new NullReferenceException();

        product.Update(request.UserId, request.Name, request.Description, request.Price);

        ProductDTO productDTO = new ProductDTO(product.Id, product.UserId, product.Name,product.Description, product.Price, product.CreatedAt, product.UpdatedAt);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return productDTO;
    }
}
