using Microsoft.EntityFrameworkCore;
using SalesSystem.Modules.Products.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SalesSystem.Modules.Products.Infrastructure.Persistence
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(100);
            builder.Property(p => p.Description).HasMaxLength(255);
            builder.Property(p => p.Price).HasColumnType("decimal(5,2)");
            builder.Property(p => p.Stock).HasMaxLength(4);
            builder.Property(p => p.CreateAt);
            builder.Property(p => p.UpdateAt);
            builder.Property(p => p.DeleteAt);
            builder.Property(p => p.IsUpdated);
            builder.Property(p => p.IsDeleted);

            builder.Property(p => p.Id).HasConversion(produtId => produtId!.Value, value => new ProductId(value));
        }
    }
}
