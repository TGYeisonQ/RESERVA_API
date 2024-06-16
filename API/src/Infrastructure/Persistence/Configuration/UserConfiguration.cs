
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure (EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.FirsName).IsRequired().HasMaxLength(30);

        builder.Property(b => b.LastName).IsRequired().HasMaxLength(30);

        builder.Property(b => b.Email).IsRequired();

        builder.HasIndex(b => b.Email).IsUnique();

        builder.Property(b => b.Password).IsRequired();
    }
}
