using HardCode.TestTask.ProductCatalog.Entities.Models;

namespace HardCode.TestTask.ProductCatalog.Repository.Extensions;

public static class ProductRepositoryExtensions
{
    public static IQueryable<Product> FilterByPrice(this IQueryable<Product> products, decimal min, decimal max) =>
        products.Where(product => product.Price >= min &&
                                  product.Price <= max);

    public static IQueryable<Product> FilterByCategory(this IQueryable<Product> products, int? category) =>
        products.Where(product => !category.HasValue || product.CategoryId == category.Value);

    public static IQueryable<Product> SearchByName(this IQueryable<Product> products, string? name)
    {
        name = name?.Trim().ToLower();
        return products.Where(product =>
            string.IsNullOrEmpty(name) || product.Name.ToLower().Contains(name));
    }

    public static IQueryable<Product> SearchByDescription(this IQueryable<Product> products, string? description)
    {
        description = description?.Trim().ToLower();
        return products.Where(product =>
            string.IsNullOrEmpty(description) ||
            product.Description != null && product.Description.ToLower().Contains(description));
    }
}