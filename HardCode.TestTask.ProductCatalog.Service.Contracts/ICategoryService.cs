using HardCode.TestTask.ProductCatalog.Shared.DataTransferObjects;

namespace HardCode.TestTask.ProductCatalog.Service.Contracts;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllAsync();
}