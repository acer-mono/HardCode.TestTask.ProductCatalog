using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HardCode.TestTask.ProductCatalog.Shared.RequestFeatures;

namespace HardCode.TestTask.ProductCatalog.Entities.Models;

[Table("attribute")]
public class Attribute
{
    [Column("id"), Key] public int Id { get; set; }
    [Column("name")] public string Name { get; set; }

    [Column("attribute_type_id")] public int AttributeTypeId { get; set; }
    public AttributeType Type { get; set; }

    [Column("category_id")] public int CategoryId { get; set; }
    public Category Category { get; set; }

    public ICollection<ProductCategoryAttribute> ProductAttributes { get; set; }

    public Func<Product, bool> GetPredicate(CategoryAttributeParameters parameters)
    {
        switch (Type.Name)
        {
            case "boolean" when parameters.Equal != null && bool.TryParse(parameters.Equal, out var value):
                return product => product.Attributes.Any(a =>
                    a.Attribute.Id == parameters.Id && bool.Parse(a.Value) == value);
            case "boolean":
                return _ => true;
            case "string" when parameters.Equal != null:
                return product => product.Attributes.Any(a =>
                    a.Attribute.Id == parameters.Id && a.Value == parameters.Equal);
            case "string" when parameters.Contain != null:
                return product => product.Attributes.Any(a =>
                    a.Attribute.Id == parameters.Id &&
                    a.Value.ToLower().Contains(parameters.Contain.ToLower()));
            case "string":
                return _ => true;
            case "integer" when parameters.Equal != null && int.TryParse(parameters.Equal, out var value):
                return product => product.Attributes.Any(a =>
                    a.Attribute.Id == parameters.Id && int.Parse(a.Value) == value);
            case "integer" when parameters.From != null && int.TryParse(parameters.From, out var from)
                                || parameters.To != null && int.TryParse(parameters.To, out var to):
                if (!int.TryParse(parameters.From, out from))
                {
                    from = int.MinValue;
                }
                
                if (!int.TryParse(parameters.To, out to))
                {
                    to = int.MaxValue;
                }

                return product => product.Attributes.Any(a =>
                    a.Attribute.Id == parameters.Id && int.Parse(a.Value) >= from && int.Parse(a.Value) <= to);
            case "integer":
                return _ => true;
            case "decimal" when parameters.Equal != null && decimal.TryParse(parameters.Equal, out var value):
                return product => product.Attributes.Any(a =>
                    a.Attribute.Id == parameters.Id && decimal.Parse(a.Value) == value);
            case "decimal" when parameters.From != null && decimal.TryParse(parameters.From, out var from)
                                || parameters.To != null && decimal.TryParse(parameters.To, out var to):
                if (!decimal.TryParse(parameters.From, out from))
                {
                    from = decimal.MinValue;
                }
                
                if (!decimal.TryParse(parameters.To, out to))
                {
                    to = decimal.MaxValue;
                }
                return product => product.Attributes.Any(a =>
                    a.Attribute.Id == parameters.Id && decimal.Parse(a.Value) >= from && decimal.Parse(a.Value) <= to);
            case "decimal":
                return _ => true;
            default:
                return _ => true;
        }
    }

    public bool ValidateValue(string value) =>
        Type.Name switch
        {
            "boolean" => bool.TryParse(value, out _),
            "string" => true,
            "integer" => int.TryParse(value, out _),
            "decimal" => decimal.TryParse(value, out _),
            _ => false
        };
}