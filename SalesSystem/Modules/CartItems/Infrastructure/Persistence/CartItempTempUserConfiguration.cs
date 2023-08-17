using Microsoft.EntityFrameworkCore;
using SalesSystem.Modules.Products.Domain;
using SalesSystem.Modules.CartItems.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SalesSystem.Modules.CartItems.Infrastructure.Persistence
{
    public class CartItempTempUserConfiguration : IEntityTypeConfiguration<TempCartItem>
    {
        public void Configure(EntityTypeBuilder<TempCartItem> builder)
        {
            builder.HasKey(tu => tu.Id);

            builder.Property(ci => ci.ProductId).HasConversion(produtId => produtId!.Value, value => new ProductId(value));
        }
    }
}
