using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Odyssey.Domain.Support;

namespace Odyssey.Infrastructure.Common.Persistence.Configurations;

public class IssueConfiguration : IEntityTypeConfiguration<Issue>
{
    public void Configure(EntityTypeBuilder<Issue> builder)
    {
        builder.ToTable("Issues");
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id).ValueGeneratedOnAdd();

        builder.Property(i => i.ClientUserName).IsRequired().HasMaxLength(200);
        builder.Property(i => i.AssignedAdminUserName).HasMaxLength(200);
        builder.Property(i => i.issueStatus).IsRequired();

        // Client is excluded from the model, so keep the client reference as a scalar username only.
        builder.Ignore(i => i.clinet);

        // Admin has no UserName property, so keep the admin assignment as a scalar username only.
        builder.Ignore(i => i.AssignedAdmin);
    }
}
