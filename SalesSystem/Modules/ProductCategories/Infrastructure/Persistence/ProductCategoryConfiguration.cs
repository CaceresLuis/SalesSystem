using Microsoft.EntityFrameworkCore;
using SalesSystem.Modules.Products.Domain;
using SalesSystem.Modules.Categories.Domain;
using SalesSystem.Modules.ProductCategories.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SalesSystem.Modules.ProductCategories.Infrastructure.Persistence
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.ProductId).HasConversion(produtId => produtId!.Value, value => new ProductId(value));
            builder.Property(c => c.CategoryId).HasConversion(categoryId => categoryId!.Value, value => new CategoryId(value));
        }
    }
}
