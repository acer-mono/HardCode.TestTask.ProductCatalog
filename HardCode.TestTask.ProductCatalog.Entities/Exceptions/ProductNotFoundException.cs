using HardCode.TestTask.ProductCatalog.Entities.Exceptions.Base;

namespace HardCode.TestTask.ProductCatalog.Entities.Exceptions;

public sealed class ProductNotFoundException : NotFoundException
{
    public ProductNotFoundException() : base("Product was not found")
    {
    }
}