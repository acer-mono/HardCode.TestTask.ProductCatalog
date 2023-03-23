using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HardCode.TestTask.ProductCatalog.Entities.Models;

[Table("attribute")]
public class Attribute
{
    [Column("id"), Key]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; }
    
    [Column("attribute_type_id")]
    public int AttributeTypeId { get; set; }
    public AttributeType Type { get; set; }
    
    [Column("category_id")]
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    
    public ICollection<ProductCategoryAttribute> ProductAttributes { get; set; }
}