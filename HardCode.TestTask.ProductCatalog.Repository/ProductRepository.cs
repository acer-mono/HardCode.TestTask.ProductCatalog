using HardCode.TestTask.ProductCatalog.Contracts;
using HardCode.TestTask.ProductCatalog.Entities.Models;
using HardCode.TestTask.ProductCatalog.Repository.Extensions;
using Microsoft.EntityFrameworkCore;

namespace HardCode.TestTask.ProductCatalog.Repository;

public sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public void Add(Product product) => Create(product);

    public async Task<Product?> GetByIdAsync(int id) =>
        await RepositoryContext
            .Products
            .Include(product => product.Category)
            .Include(product => product.Attributes)
            .ThenInclude(attribute => attribute.Attribute)
            .SingleOrDefaultAsync(product => product.Id == id);

    public async Task<IEnumerable<Product>> GetAll(string? name,
        string? description,
        decimal minPrice,
        decimal maxPrice,
        int? category) =>
        await FindAll(false)
            .SearchByName(name)
            .SearchByDescription(description)
            .FilterByPrice(minPrice, maxPrice)
            .FilterByCategory(category)
            .ToListAsync();
}