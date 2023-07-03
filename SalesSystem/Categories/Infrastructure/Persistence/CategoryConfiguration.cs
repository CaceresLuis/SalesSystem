using Microsoft.EntityFrameworkCore;
using SalesSystem.Categories.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SalesSystem.Categories.Infrastructure.Persistence
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.Property(c => c.CreateAt).IsRequired();
            builder.Property(c => c.UpdateAt);
            builder.Property(c => c.DeleteAt);
            builder.Property(c => c.IsUpdated);
            builder.Property(c => c.IsDeleted);

            builder.Property(c => c.Id).HasConversion(categoryId => categoryId.Value, value => new CategoryId(value));
        }
    }
}
