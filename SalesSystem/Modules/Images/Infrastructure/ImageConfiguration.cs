using Microsoft.EntityFrameworkCore;
using SalesSystem.Modules.Images.Domain;
using SalesSystem.Modules.Products.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SalesSystem.Modules.Images.Infrastructure
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.ProductId).HasConversion(produtId => produtId!.Value, value => new ProductId(value));
        }
    }
}
