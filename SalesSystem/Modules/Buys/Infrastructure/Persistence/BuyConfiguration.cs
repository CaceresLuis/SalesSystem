using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesSystem.Modules.Buys.Domain;
using SalesSystem.Modules.CartItems.Domain;
using SalesSystem.Modules.Products.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.Modules.Buys.Infrastructure.Persistence
{
    public class BuyConfiguration : IEntityTypeConfiguration<Buy>
    {
        public void Configure(EntityTypeBuilder<Buy> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id).HasConversion(buyId => buyId!.Value, value => new BuyId(value));
            builder.Property(ci => ci.ProductId).HasConversion(produtId => produtId!.Value, value => new ProductId(value));
        }
    }
}
