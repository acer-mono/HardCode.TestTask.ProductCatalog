using HardCode.TestTask.ProductCatalog.Entities.Exceptions.Base;

namespace HardCode.TestTask.ProductCatalog.Entities.Exceptions;

public sealed class CategoryNotFoundException : NotFoundException
{
    public CategoryNotFoundException() : base("The category was not found")
    {
    }
}