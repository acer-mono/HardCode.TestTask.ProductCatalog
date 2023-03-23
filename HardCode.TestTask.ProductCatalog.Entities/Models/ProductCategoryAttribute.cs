using System.ComponentModel.DataAnnotations.Schema;

namespace HardCode.TestTask.ProductCatalog.Entities.Models;

[Table("product_category_attribute")]
public class ProductCategoryAttribute
{
    [Column("value")]
    public string Value { get; set; }
    
    [Column("attribute_id")]
    public int AttributeId { get; set; }
    public Attribute Attribute { get; set; }
    
    [Column("product_id")]
    public int ProductId { get; set; }
    public Product Product { get; set; }
}