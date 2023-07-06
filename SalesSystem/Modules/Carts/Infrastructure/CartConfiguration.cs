using Microsoft.EntityFrameworkCore;
using SalesSystem.Modules.Carts.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SalesSystem.Modules.Carts.Infrastructure
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.UserId);

            builder.Property(c => c.Id).HasConversion(cartId => cartId!.Value, value => new CartId(value));
        }
    }
}