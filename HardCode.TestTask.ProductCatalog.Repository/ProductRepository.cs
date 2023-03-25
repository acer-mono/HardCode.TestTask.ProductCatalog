using HardCode.TestTask.ProductCatalog.Contracts;
using HardCode.TestTask.ProductCatalog.Entities.Models;
using HardCode.TestTask.ProductCatalog.Repository.Extensions;
using HardCode.TestTask.ProductCatalog.Shared.RequestFeatures;
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

    public async Task<IEnumerable<Product>> GetAll(ProductParameters parameters)
    {
        var products = FindAll(false)
            .SearchByName(parameters.Name)
            .SearchByDescription(parameters.Description)
            .FilterByPrice(parameters.MinPrice, parameters.MaxPrice)
            .FilterByCategory(parameters.Category)
            .Include(product => product.Category)
            .Include(product => product.Attributes)
            .ThenInclude(attribute => attribute.Attribute);

        if (parameters.CategoryAttributes == null)
        {
            return await products.ToListAsync();
        }

        var attributePredicates = new List<Func<Product, bool>>();
        foreach (var productCategoryParameters in parameters.CategoryAttributes)
        {
            var attribute = await RepositoryContext
                .Attributes
                .Include(a => a.Type)
                .FirstOrDefaultAsync(attribute => attribute.Id == productCategoryParameters.Id);

            if (attribute == null)
            {
                continue;
            }

            var attributePredicate = attribute.GetPredicate(productCategoryParameters);
            attributePredicates.Add(attributePredicate);
        }

        bool GeneralPredicate(Product p) => attributePredicates.All(predicate => predicate(p));
        return products.Where((Func<Product, bool>) GeneralPredicate);
    }
}