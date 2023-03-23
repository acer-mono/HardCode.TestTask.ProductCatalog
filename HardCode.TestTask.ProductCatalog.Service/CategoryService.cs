using HardCode.TestTask.ProductCatalog.Contracts;
using HardCode.TestTask.ProductCatalog.Service.Contracts;

namespace HardCode.TestTask.ProductCatalog.Service;

public sealed class CategoryService : ICategoryService
{
    private IRepositoryManager _repositoryManager;

    public CategoryService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
}