using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Odyssey.Domain.Users.Customers;

namespace Odyssey.Infrastructure.Common.Persistence.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();

        // The Client/User base types are excluded from the model, so map inherited properties explicitly.
        builder.Property(c => c.UserName).IsRequired().HasMaxLength(200);
        builder.Property(c => c.Name).IsRequired().HasMaxLength(200);
        builder.Property(c => c.Email).IsRequired().HasMaxLength(300);
        builder.Property(c => c.HashedPassword).IsRequired().HasMaxLength(1000);
        builder.Property(c => c.role).IsRequired();
        builder.Property(c => c.CreatedAt).IsRequired();

        builder.HasIndex(c => c.UserName).IsUnique();
    }
}
