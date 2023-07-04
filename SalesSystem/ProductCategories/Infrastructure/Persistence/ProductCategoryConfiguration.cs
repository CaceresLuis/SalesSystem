using Microsoft.EntityFrameworkCore;
using SalesSystem.ProductCategories.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesSystem.Categories.Domain;
using SalesSystem.Products.Domain;

namespace SalesSystem.ProductCategories.Infrastructure.Persistence
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.CategoryId).HasConversion(categoryId => categoryId.Value, value => new CategoryId(value));
            builder.Property(p => p.ProductId).HasConversion(produtId => produtId.Value, value => new ProductId(value));
        }
    }
}
