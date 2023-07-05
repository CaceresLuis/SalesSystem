using SalesSystem.Carts.Domain;
using SalesSystem.Products.Domain;
using SalesSystem.CartItems.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SalesSystem.CartItems.Infrastructure.Persistence
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.CartId).HasConversion(cartId => cartId!.Value, value => new CartId(value));
            builder.Property(ci => ci.ProductId).HasConversion(produtId => produtId!.Value, value => new ProductId(value));
        }
    }
}
