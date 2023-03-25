using Microsoft.AspNetCore.Mvc;

namespace HardCode.TestTask.ProductCatalog.Shared.RequestFeatures;

/// <summary>
/// Параметры поиски продукта
/// </summary>
public sealed class ProductParameters
{
    /// <summary>
    /// Поиск по названию
    /// </summary>
    [FromQuery(Name = "name")]
    public string? Name { get; set; }

    /// <summary>
    /// Поиск по описанию
    /// </summary>
    [FromQuery(Name = "description")]
    public string? Description { get; set; }

    /// <summary>
    /// Фильтрация по цене (минимальная цена)
    /// </summary>
    [FromQuery(Name = "min-price")]
    public decimal MinPrice { get; set; } = decimal.MinValue;

    /// <summary>
    /// Фильтрация по цене (максимальная цена)
    /// </summary>
    [FromQuery(Name = "max-price")]
    public decimal MaxPrice { get; set; } = decimal.MaxValue;

    /// <summary>
    /// Фильтрация по категории
    /// </summary>
    [FromQuery(Name = "category")]
    public int? Category { get; set; }

    /// <summary>
    /// Фильтрация по атрибутам категории продукта
    /// </summary>
    [FromQuery(Name = "category-attributes")]
    public IEnumerable<CategoryAttributeParameters>? CategoryAttributes { get; set; }
}