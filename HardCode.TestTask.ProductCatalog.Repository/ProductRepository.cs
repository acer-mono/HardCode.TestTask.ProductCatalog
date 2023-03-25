using HardCode.TestTask.ProductCatalog.Contracts;
using HardCode.TestTask.ProductCatalog.Entities.Models;
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
            .SingleOrDefaultAsync(product => product.Id == id);
}