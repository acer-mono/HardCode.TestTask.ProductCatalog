using HardCode.TestTask.ProductCatalog.Contracts;
using HardCode.TestTask.ProductCatalog.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace HardCode.TestTask.ProductCatalog.Repository;

public sealed class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
{
    public CategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Category>> GetAllAsync() => await RepositoryContext.Categories.ToListAsync();
}