using Microsoft.Extensions.DependencyInjection;
using ProductService.Core;

namespace ProductService.Infrastructure;
 
public class ProductServices: IProductServices
{
    private readonly IRepository<Product> _repoProduct;
    private readonly IRepository<ProductCategory> _repoProductCategory;

    public ProductServices(IRepository<ProductCategory> repoProductCategory, 
        IRepository<Product> repoProduct)
    {
        _repoProduct = repoProduct;
        _repoProductCategory = repoProductCategory;
    }

    public async Task<Product> CreateProduct(Product product, string categoryName)
    {
        product.Category = await GetProductCategoriesByName(categoryName);
        product.CategoryId = product.Category.CategoryId;
      
        await _repoProduct.AddAsync(product);
        return product;
    }

    public async Task<bool> UpdateProduct(Product product)
    {
        //var product = await _productRepository.GetByIdAsync(id);
        if (product == null) return false;

       // product.UpdateProductDetails(name, description, price);
        await _repoProduct.UpdateAsync(product);
        return true;
    }

    public async Task<IEnumerable<Product>> GetAllProducts()
    {
       var listProduct= await _repoProduct.GetAllAsync();
        return listProduct;
    }

    public async Task<IEnumerable<ProductCategory>> GetAllProductCategories()
    {
        return await _repoProductCategory.GetAllAsync();
    }

    public async Task<ProductCategory> GetProductCategoriesById(Guid id)
    {
        return await _repoProductCategory.GetByIdAsync(id);
    }

    public async Task<ProductCategory> GetProductCategoriesByName(string name)
    {
        var allProductCategories= await _repoProductCategory.GetAllAsync();
        return allProductCategories.SingleOrDefault(pc => pc.Name.Equals(name, StringComparison.Ordinal));
    } 
    public async Task<Product> GetProductById(Guid id)
    {
        return await _repoProduct.GetByIdAsync(id,p=>p.Category);
    }
}

public interface IProductServices
{
    Task<Product> CreateProduct(Product product, string categoryName);
    Task<bool> UpdateProduct(Product product);
    Task<IEnumerable<Product>> GetAllProducts();
    Task<Product> GetProductById(Guid id);
}