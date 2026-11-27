using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Odyssey.Domain.Users.Admins;

namespace Odyssey.Infrastructure.Common.Persistence.Configurations;

public class CreateAdminRequestConfiguration : IEntityTypeConfiguration<CreateAdminRequest>
{
    public void Configure(EntityTypeBuilder<CreateAdminRequest> builder)
    {
        builder.ToTable("CreateAdminRequests");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();

        builder.Property(c => c.Situation).IsRequired();

        // User is excluded from the model.
        builder.Ignore(c => c.user);
    }
}
