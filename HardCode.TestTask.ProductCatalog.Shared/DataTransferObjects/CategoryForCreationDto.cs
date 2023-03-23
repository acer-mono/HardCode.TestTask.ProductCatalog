namespace HardCode.TestTask.ProductCatalog.Shared.DataTransferObjects;

public sealed class CategoryForCreationDto
{
    public string Name { get; set; }
    public IEnumerable<AttributeForCreationDto> Attributes { get; set; }
}