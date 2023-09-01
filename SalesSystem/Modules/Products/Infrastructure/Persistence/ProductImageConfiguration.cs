using Microsoft.EntityFrameworkCore;
using SalesSystem.Modules.Products.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SalesSystem.Modules.Products.Infrastructure.Persistence
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.HasKey(pi => pi.Id);

            builder.Property(pi => pi.ProductId).HasConversion(produtId => produtId!.Value, value => new ProductId(value));
        }
    }
}
