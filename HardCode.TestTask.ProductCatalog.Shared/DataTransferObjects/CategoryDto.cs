namespace HardCode.TestTask.ProductCatalog.Shared.DataTransferObjects;

/// <summary>
/// DTO для отображения категории
/// </summary>
/// <param name="Id">Идентификатор</param>
/// <param name="Name">Имя</param>
/// <param name="Attributes">Список атрибутов</param>
public sealed record CategoryDto(int Id, string Name, IEnumerable<AttributeDto> Attributes);