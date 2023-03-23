namespace HardCode.TestTask.ProductCatalog.Service.Contracts;

public interface IServiceManager
{
    ICategoryService CategoryService { get; }
    IProductService ProductService { get; }
}