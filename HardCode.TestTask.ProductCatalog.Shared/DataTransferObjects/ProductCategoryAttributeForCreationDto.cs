namespace HardCode.TestTask.ProductCatalog.Shared.DataTransferObjects;

/// <summary>
/// DTO для добавления значения атрибута категории продукта
/// </summary>
public sealed record ProductCategoryAttributeForCreationDto
{
    /// <summary>
    /// Идентификатор атрибута категории
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Значение атрибута
    /// </summary>
    public object Value { get; set; }
}