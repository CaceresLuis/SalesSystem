using Microsoft.EntityFrameworkCore;
using SalesSystem.Modules.Carts.Domain;
using SalesSystem.Modules.Products.Domain;
using SalesSystem.Modules.CartItems.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SalesSystem.Modules.CartItems.Infrastructure.Persistence
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.CartId).HasConversion(cartId => cartId!.Value, value => new CartId(value));
            builder.Property(ci => ci.Id).HasConversion(cartItemId => cartItemId!.Value, value => new CartItemId(value));
            builder.Property(ci => ci.ProductId).HasConversion(produtId => produtId!.Value, value => new ProductId(value));
        }
    }
}
