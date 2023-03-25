namespace HardCode.TestTask.ProductCatalog.Shared.DataTransferObjects;

/// <summary>
/// DTO для создания атрибута категории
/// </summary>
public sealed record AttributeForCreationDto
{
    /// <summary>
    /// Название атрибута
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Тип атрибута (доступны: boolean, decimal, integer, string)
    /// </summary>
    public string Type { get; set; }
}