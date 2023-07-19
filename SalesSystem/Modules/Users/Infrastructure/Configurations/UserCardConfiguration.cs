using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesSystem.Modules.Users.Domain.Entities;

namespace SalesSystem.Modules.Users.Infrastructure.Configurations
{
    public class UserCardConfiguration : IEntityTypeConfiguration<UserCard>
    {
        public void Configure(EntityTypeBuilder<UserCard> builder)
        {
            builder.HasKey(uc => uc.Id);
            builder.Property(uc => uc.OwnerCard).IsRequired();
            builder.Property(uc => uc.CardNumber).IsRequired();
            builder.Property(uc => uc.ExpiredDate).IsRequired();
            builder.Property(uc => uc.CVC).IsRequired();
        }
    }
}