using HardCode.TestTask.ProductCatalog.Contracts;
using HardCode.TestTask.ProductCatalog.Service.Contracts;

namespace HardCode.TestTask.ProductCatalog.Service;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<ICategoryService> _categoryService;
    private readonly Lazy<IProductService> _productService;
    
    public ServiceManager(IRepositoryManager repositoryManager)
    {
        _categoryService = new Lazy<ICategoryService>(() => new 
            CategoryService(repositoryManager));
        _productService = new Lazy<IProductService>(() => new
            ProductService(repositoryManager));

    }

    public ICategoryService CategoryService => _categoryService.Value;
    public IProductService ProductService => _productService.Value;
}