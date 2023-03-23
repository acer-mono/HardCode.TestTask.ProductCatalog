using HardCode.TestTask.ProductCatalog.Contracts;
using HardCode.TestTask.ProductCatalog.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace HardCode.TestTask.ProductCatalog.Repository;

public sealed class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
{
    public CategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Category>> GetAllAsync() =>
        await RepositoryContext
            .Categories
            .Include(category => category.Attributes)
            .ThenInclude(attribute => attribute.Type)
            .ToListAsync();
    public async Task<Category?> GetByIdAsync(int id) =>
        await RepositoryContext
            .Categories
            .Include(category => category.Attributes)
            .ThenInclude(attribute => attribute.Type)
            .FirstOrDefaultAsync(category => category.Id == id);

    public async Task<IEnumerable<AttributeType>> GetAllowedAttributeTypesAsync() =>
        await RepositoryContext.AttributeTypes.ToListAsync();

    public void Add(Category category) => Create(category);
    public void Remove(Category category) => Delete(category);
}