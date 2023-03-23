using HardCode.TestTask.ProductCatalog.Entities.Models;

namespace HardCode.TestTask.ProductCatalog.Contracts;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category?> GetByIdAsync(int id);
    Task<List<AttributeType>> GetAllowedAttributeTypesAsync();
    void Add(Category category);
    void Remove(Category category);
}