using System.ComponentModel.DataAnnotations.Schema;

namespace ProductService.Core;

[Table("Products")]
public class Product
{
    public Guid Id { get;  set; }
    public string Name { get;  set; }
    public string? Description { get;  set; }
    public decimal Price { get;  set; }
    public int StockQuantity { get;  set; }
    public bool IsActive { get;  set; }

    // Foreign Key to ProductCategory
    public Guid CategoryId { get;  set; }

    // Navigation Property (Belongs to One Category)
    public ProductCategory Category { get;  set; }

}
