using HardCode.TestTask.ProductCatalog.Entities.Models;

namespace HardCode.TestTask.ProductCatalog.Contracts;

public interface IProductRepository
{
    void Add(Product product);
    Task<Product?> GetByIdAsync(int id);
    Task<IEnumerable<Product>> GetAll(string? name,
        string? description,
        decimal minPrice,
        decimal maxPrice,
        int? category);
}