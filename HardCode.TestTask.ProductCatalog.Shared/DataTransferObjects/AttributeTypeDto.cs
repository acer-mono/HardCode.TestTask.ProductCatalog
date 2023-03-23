namespace HardCode.TestTask.ProductCatalog.Shared.DataTransferObjects;

/// <summary>
/// DTO для отображения типа атрибута. Список типов предопределен, создается при первой миграции.
/// </summary>
/// <param name="Id">Идентификатор</param>
/// <param name="Name">Имя(boolean, decimal, integer, string)</param>
public sealed record AttributeTypeDto(int Id, string Name);