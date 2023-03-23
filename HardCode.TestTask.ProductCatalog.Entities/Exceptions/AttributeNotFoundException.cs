using HardCode.TestTask.ProductCatalog.Entities.Exceptions.Base;

namespace HardCode.TestTask.ProductCatalog.Entities.Exceptions;

public sealed class AttributeNotFoundException : NotFoundException
{
    public AttributeNotFoundException(string name) : base($"The \"{name}\" attribute was not found")
    {
    }
}