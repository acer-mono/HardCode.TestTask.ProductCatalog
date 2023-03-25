namespace HardCode.TestTask.ProductCatalog.Shared.DataTransferObjects;

/// <summary>
/// DTO для отображения значений дополнительных аттрибутов категории
/// </summary>
/// <param name="Id">Идентификатор</param>
/// <param name="Name">Имя</param>
/// <param name="Value">Значение</param>
public sealed record ProductCategoryAttributeDto(int Id, string Name, string Value);