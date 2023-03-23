using HardCode.TestTask.ProductCatalog.Contracts;
using HardCode.TestTask.ProductCatalog.Service.Contracts;

namespace HardCode.TestTask.ProductCatalog.Service;

public sealed class ProductService : IProductService
{
    private IRepositoryManager _repositoryManager;

    public ProductService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
}