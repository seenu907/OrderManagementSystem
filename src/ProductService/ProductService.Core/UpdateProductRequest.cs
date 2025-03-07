
using System.Xml.Linq;

namespace ProductService.Core;

public record UpdateProductRequest(string Name, string Description, decimal Price)
{ 
    public Product UpdateProductDetails(Guid id)
    {
        if (string.IsNullOrWhiteSpace(Name))
            throw new ArgumentException("Product name is required.");
        if (Price <= 0)
            throw new ArgumentException("Product price must be greater than zero.");

        return new Product
        {
            Id = id,
            Name = Name,
            Description = Description,
            Price = Price,
        }; 
    }
}