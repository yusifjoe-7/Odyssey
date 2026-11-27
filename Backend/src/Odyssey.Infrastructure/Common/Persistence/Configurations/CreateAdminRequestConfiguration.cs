using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Odyssey.Domain.Users.Admins;

namespace Odyssey.Infrastructure.Common.Persistence.Configurations;

public class CreateAdminRequestConfiguration : IEntityTypeConfiguration<CreateAdminRequest>
{
    public void Configure(EntityTypeBuilder<CreateAdminRequest> builder)
    {
        builder.ToTable("CreateAdminRequests");
         builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).ValueGeneratedOnAdd();

        // The User base type is excluded from the model, so map inherited properties explicitly.
        builder.Property(a => a.Name).IsRequired().HasMaxLength(200);
        builder.Property(a => a.Email).IsRequired().HasMaxLength(300);
        builder.Property(a => a.HashedPassword).IsRequired().HasMaxLength(1000);
        builder.Property(a => a.role).IsRequired();
        builder.Property(a => a.CreatedAt).IsRequired();

        builder.Property(c => c.Situation).IsRequired();

    }
}
