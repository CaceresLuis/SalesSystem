﻿using Microsoft.EntityFrameworkCore;
using SalesSystem.Modules.Users.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesSystem.Modules.Users.Domain.ValueObjetcs;

namespace SalesSystem.Modules.Users.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Email).IsUnicode(true);
            builder.Property(u => u.LastName).HasMaxLength(150);
            builder.Property(u => u.FirstName).HasMaxLength(150);

            builder.Ignore(u => u.FullName);

            builder.Property(c => c.PhoneNumber).HasConversion(phoneNumber => phoneNumber!.Value, value => PhoneNumber.Create(value)!).HasMaxLength(9);

        }
    }
}
