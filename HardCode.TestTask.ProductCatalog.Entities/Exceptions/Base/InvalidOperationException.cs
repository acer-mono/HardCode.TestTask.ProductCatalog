namespace HardCode.TestTask.ProductCatalog.Entities.Exceptions.Base;

public abstract class InvalidOperationException : Exception
{
    protected InvalidOperationException(string message) : base(message)
    {
    }
}
