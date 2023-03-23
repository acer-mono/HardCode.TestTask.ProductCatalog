using HardCode.TestTask.ProductCatalog.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace HardCode.TestTask.ProductCatalog.Repository;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductCategoryAttribute>()
            .HasKey(attribute => new { attribute.ProductId, attribute.AttributeId });
        
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Product>? Products { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<AttributeType>? AttributeTypes { get; set; }
}