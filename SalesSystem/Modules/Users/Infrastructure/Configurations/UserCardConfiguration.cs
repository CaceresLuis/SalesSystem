using Microsoft.EntityFrameworkCore;
using SalesSystem.Modules.Users.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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