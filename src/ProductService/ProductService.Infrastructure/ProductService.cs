using ProductService.Core;

namespace ProductService.Infrastructure;
 
public class ProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> CreateProduct(string name, string description, decimal price, int stock)
    {
        var product = new Product(name, description, price, stock);
        await _productRepository.AddAsync(product);
        return product;
    }

    public async Task<bool> UpdateProduct(Guid id, string name, string description, decimal price)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null) return false;

        product.UpdateProductDetails(name, description, price);
        await _productRepository.UpdateAsync(product);
        return true;
    }

    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        return await _productRepository.GetAllAsync();
    }
}
