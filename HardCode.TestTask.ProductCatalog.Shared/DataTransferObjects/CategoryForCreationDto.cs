namespace HardCode.TestTask.ProductCatalog.Shared.DataTransferObjects;

/// <summary>
/// DTO для создания категории
/// </summary>
public sealed class CategoryForCreationDto
{
    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Список атрибутов
    /// </summary>
    public IEnumerable<AttributeForCreationDto> Attributes { get; set; }
}