using HardCode.TestTask.ProductCatalog.Entities.Exceptions.Base;

namespace HardCode.TestTask.ProductCatalog.Entities.Exceptions;

public sealed class CategoryAttributeNotFoundException : NotFoundException
{
    public CategoryAttributeNotFoundException() : base("Some category attributes was not found")
    {
    }
}