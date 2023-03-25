using HardCode.TestTask.ProductCatalog.Entities.Models;
using HardCode.TestTask.ProductCatalog.Shared.RequestFeatures;

namespace HardCode.TestTask.ProductCatalog.Contracts;

public interface IProductRepository
{
    void Add(Product product);
    Task<Product?> GetByIdAsync(int id);
    Task<IEnumerable<Product>> GetAll(ProductParameters parameters);
}