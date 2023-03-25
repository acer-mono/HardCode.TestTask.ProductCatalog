namespace HardCode.TestTask.ProductCatalog.Shared.RequestFeatures;

/// <summary>
/// Параметры поиски продукта
/// </summary>
public sealed class ProductParameters
{
    /// <summary>
    /// Поиск по названию
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Поиск по описанию
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Фильтрация по цене (минимальная цена)
    /// </summary>
    public decimal? MinPrice { get; set; } = decimal.MinValue;

    /// <summary>
    /// Фильтрация по цене (максимальная цена)
    /// </summary>
    public decimal? MaxPrice { get; set; } = decimal.MaxValue;

    /// <summary>
    /// Фильтрация по категории
    /// </summary>
    public int? Category { get; set; }

    /// <summary>
    /// Фильтрация по атрибутам категории продукта
    /// </summary>
    public IEnumerable<CategoryAttributeParameters>? CategoryAttributes { get; set; }
}