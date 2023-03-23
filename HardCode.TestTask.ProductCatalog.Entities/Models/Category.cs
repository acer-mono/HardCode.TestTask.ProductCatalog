using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HardCode.TestTask.ProductCatalog.Entities.Models;

[Table("category")]
public class Category
{
    [Column("id"), Key]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; }
    
    public ICollection<Attribute> Attributes { get; set; }
}