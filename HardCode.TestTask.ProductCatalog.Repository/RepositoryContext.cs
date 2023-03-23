using HardCode.TestTask.ProductCatalog.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Attribute = HardCode.TestTask.ProductCatalog.Entities.Models.Attribute;

namespace HardCode.TestTask.ProductCatalog.Repository;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options)
        : base(options)
    {
    }
    
    public DbSet<Product>? Products { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<AttributeType>? AttributeTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        SeedAttributeTypes(modelBuilder);
        modelBuilder.Entity<Attribute>().Property(attribute => attribute.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<AttributeType>().Property(type => type.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Category>().Property(category => category.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Product>().Property(product => product.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<ProductCategoryAttribute>()
            .HasKey(attribute => new { attribute.ProductId, attribute.AttributeId });
        
        base.OnModelCreating(modelBuilder);
    }
    
    private static void SeedAttributeTypes(ModelBuilder builder)
    {
        builder.Entity<AttributeType>(u =>
        {
            var @decimal = new AttributeType {Id = 1, Name = "decimal"};
            var integer = new AttributeType {Id = 2, Name = "integer"};
            var @string = new AttributeType {Id = 3, Name = "string"};
            var boolean = new AttributeType {Id = 4, Name = "boolean"};
            u.HasData(@decimal, integer, @string, boolean);
        });
    }
}