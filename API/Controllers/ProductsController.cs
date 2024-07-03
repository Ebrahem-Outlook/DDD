
using API.Contracts.Product;
using Application.Products.Commands.CreateProduct;
using Application.Products.Commands.DeleteProduct;
using Application.Products.Commands.UpdateProduct;
using Application.Products.Queries.GetAllProduct;
using Application.Products.Queries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[Controller]")]
public sealed class ProductsController : ControllerBase
{
    private readonly ISender _sender;

    public ProductsController(ISender sender) => _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductRequest request) => 
        Ok(await _sender.Send(
            new CreateProductCommand(
                request.UserId, 
                request.Name,
                request.Description, 
                request.Price)));

    [HttpPut]
    public async Task<IActionResult> Update(UpdateProductRequest request) =>
        Ok(await _sender.Send(new UpdateProductCommand(
            request.ProductId, 
            request.UserId,
            request.Name, 
            request.Description, 
            request.Price)));

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid productId) => Ok(await _sender.Send(new DeleteProductCommand(productId)));

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _sender.Send(new GetAllProductsQuery()));

    [HttpGet("id")]
    public async Task<IActionResult> GetById(Guid productId) => Ok(await _sender.Send(new GetProductByIdQuery(productId)));
}
