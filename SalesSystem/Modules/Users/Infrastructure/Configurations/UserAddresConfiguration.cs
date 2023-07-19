using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesSystem.Modules.Users.Domain.Entities;

namespace SalesSystem.Modules.Users.Infrastructure.Configurations
{
    public class UserAddresConfiguration : IEntityTypeConfiguration<UserAddres>
    {
        public void Configure(EntityTypeBuilder<UserAddres> builder)
        {
            builder.HasKey(ua => ua.Id);
            builder.Property(ua => ua.City).IsRequired().HasMaxLength(50);
            builder.Property(ua => ua.Department).IsRequired().HasMaxLength(50);
            builder.Property(ua => ua.AddressSpecific).IsRequired().HasMaxLength(250);
        }
    }
}