using InvalidOperationException = HardCode.TestTask.ProductCatalog.Entities.Exceptions.Base.InvalidOperationException;

namespace HardCode.TestTask.ProductCatalog.Entities.Exceptions;

public sealed class IncompatibleCategoryAttributeTypeException : InvalidOperationException
{
    public IncompatibleCategoryAttributeTypeException() : base("Incompatible attribute type")
    {
    }
}