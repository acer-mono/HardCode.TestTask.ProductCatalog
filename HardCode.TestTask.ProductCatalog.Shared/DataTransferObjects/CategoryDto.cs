namespace HardCode.TestTask.ProductCatalog.Shared.DataTransferObjects;

/// <summary>
/// DTO для отображения категории
/// </summary>
public sealed record CategoryDto
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
    /// Список атрибутов
    /// </summary>
    public IEnumerable<AttributeDto> Attributes { get; set; }
}