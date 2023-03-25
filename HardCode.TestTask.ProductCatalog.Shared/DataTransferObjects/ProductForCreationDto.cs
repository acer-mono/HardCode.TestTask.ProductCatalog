namespace HardCode.TestTask.ProductCatalog.Shared.DataTransferObjects;

/// <summary>
/// DTO для создания продукта
/// </summary>
public sealed record ProductForCreationDto
{
    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Описание
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// Цена
    /// </summary>
    public decimal Price { get; set; }
    /// <summary>
    /// Изображение
    /// </summary>
    public string? Image { get; set; }
    /// <summary>
    /// Идентификатор категории
    /// </summary>
    public int CategoryId { get; set; }
    /// <summary>
    /// Дополнительные поля категории товара
    /// </summary>
    public IEnumerable<ProductCategoryAttributeForCreationDto> Attributes { get; set; }
}