using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HardCode.TestTask.ProductCatalog.Entities.Models;

[Table("product")]
public class Product
{
    [Column("id"), Key]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; }
    [Column("description")]
    public string? Description { get; set; }
    [Column("decimal")]
    public decimal Price { get; set; }
    [Column("image")]
    public string? Image { get; set; }
    
    [Column("category_id")]
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    
    public ICollection<ProductCategoryAttribute> Attributes { get; set; }
}