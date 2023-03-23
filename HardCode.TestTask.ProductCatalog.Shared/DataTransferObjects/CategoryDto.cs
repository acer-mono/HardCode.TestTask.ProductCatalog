namespace HardCode.TestTask.ProductCatalog.Shared.DataTransferObjects;

public sealed record CategoryDto(int Id, string Name, IEnumerable<AttributeDto> Attributes);