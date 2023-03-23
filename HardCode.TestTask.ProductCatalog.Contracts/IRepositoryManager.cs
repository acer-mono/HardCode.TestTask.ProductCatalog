namespace HardCode.TestTask.ProductCatalog.Contracts;

public interface IRepositoryManager
{
    ICategoryRepository CategoryRepository { get; }
    IProductRepository ProductRepository { get; }
    Task SaveAsync();
}