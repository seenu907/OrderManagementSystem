using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductService.Core;

[Table("ProductCategories")]
public class ProductCategory
{ 
    public Guid CategoryId { get; set; } 
     
    public string Name { get; set; } 
    public string? Description { get; set; }

    public Guid? ParentCategoryId { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    //// Navigation Property: One Category has many Products
    //public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}