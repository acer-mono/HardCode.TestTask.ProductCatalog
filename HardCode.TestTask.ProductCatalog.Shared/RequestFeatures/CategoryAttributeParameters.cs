namespace HardCode.TestTask.ProductCatalog.Shared.RequestFeatures;

/// <summary>
/// Поиск по значению атрибутов категории
/// </summary>
public sealed record CategoryAttributeParameters
{
    /// <summary>
    /// Идентификатор атрибута категории
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Фильтрация по диапазону значений (минимальное значение диапазона)
    /// Поддерживается типами decimal и integer
    /// Игнорируется другими типами
    /// Если указано значение Equal - игнорируется
    /// </summary>
    public string? From { get; set; }
    /// <summary>
    /// Фильтрация по диапазону значений (максимальное значение диапазона)
    /// Поддерживается типами decimal и integer
    /// Игнорируется другими типами
    /// Если указано значение Equal - игнорируется
    /// </summary>
    public string? To { get; set; }
    /// <summary>
    /// Поиск по точному значению
    /// </summary>
    public string? Equal { get; set; }
    /// <summary>
    /// Поиск по совпадению, поддерживается string
    /// Если указано значение Equal - игнорируется
    /// </summary>
    public string? Contain { get; set; }
}