using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Odyssey.Domain.Users.Owners;

namespace Odyssey.Infrastructure.Common.Persistence.Configurations;

public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
{
    public void Configure(EntityTypeBuilder<Owner> builder)
    {
        builder.ToTable("Owners");
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id).ValueGeneratedOnAdd();

        // The Client/User base types are excluded from the model, so map inherited properties explicitly.
        builder.Property(o => o.UserName).IsRequired().HasMaxLength(200);
        builder.Property(o => o.Name).IsRequired().HasMaxLength(200);
        builder.Property(o => o.Email).IsRequired().HasMaxLength(300);
        builder.Property(o => o.HashedPassword).IsRequired().HasMaxLength(1000);
        builder.Property(o => o.Role).IsRequired();
        builder.Property(o => o.CreatedAt).IsRequired();

        builder.HasIndex(o => o.UserName).IsUnique();
    }
}
