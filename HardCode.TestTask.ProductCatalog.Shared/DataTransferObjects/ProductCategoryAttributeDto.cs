namespace HardCode.TestTask.ProductCatalog.Shared.DataTransferObjects;

/// <summary>
/// DTO для отображения значений дополнительных аттрибутов категории
/// </summary>
public sealed record ProductCategoryAttributeDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Значение
    /// </summary>
    public string Value { get; set; }
}