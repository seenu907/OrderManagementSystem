using Microsoft.AspNetCore.Mvc;
using ProductService.Core;
using ProductService.Infrastructure;

namespace ProductServiceAPI.Controllers;

[ApiController]
[Route("api/products")]  
public class ProductController : ControllerBase
{
    private readonly IProductServices _productServices;

    public ProductController(IProductServices productServices)
    {
        _productServices = productServices;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
    {
        var product = await _productServices.CreateProduct(request.ToProduct(), request.CategoryName);
        return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product); //nameof(GetProductById)
    }

    [HttpGet("GetAllProducts")]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _productServices.GetAllProducts();
        return Ok(products);
    }
    [HttpGet("GetProduct/{id}")]
    public async Task<IActionResult> GetProductById(Guid id)
    {
        var products = await _productServices.GetProductById(id);
        return Ok(products);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductRequest request)
    {
        var updated = await _productServices.UpdateProduct(request.UpdateProductDetails(id));
        return updated ? NoContent() : NotFound();
    }
}

//public record CreateProductRequest(string Name, string Description, decimal Price, int Stock);
//public record UpdateProductRequest(string Name, string Description, decimal Price);
