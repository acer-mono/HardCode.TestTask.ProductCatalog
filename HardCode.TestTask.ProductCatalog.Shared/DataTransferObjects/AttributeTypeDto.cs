namespace HardCode.TestTask.ProductCatalog.Shared.DataTransferObjects;

/// <summary>
/// DTO для отображения типа атрибута. Список типов предопределен, создается при первой миграции.
/// </summary>
public sealed record AttributeTypeDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Имя(boolean, decimal, integer, string)
    /// </summary>
    public string Name { get; set; }
}