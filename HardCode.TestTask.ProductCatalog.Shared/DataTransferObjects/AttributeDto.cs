namespace HardCode.TestTask.ProductCatalog.Shared.DataTransferObjects;

/// <summary>
/// DTO для отображения атрибута
/// </summary>
public sealed record AttributeDto
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
    /// Название типа
    /// </summary>
    public string Type { get; set; }
}