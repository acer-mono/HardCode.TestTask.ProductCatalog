using HardCode.TestTask.ProductCatalog.Entities.Models;

namespace HardCode.TestTask.ProductCatalog.Contracts;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllAsync();
}