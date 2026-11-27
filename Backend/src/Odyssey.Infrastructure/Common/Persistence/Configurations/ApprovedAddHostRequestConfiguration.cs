using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Odyssey.Domain.Hosts;
using Odyssey.Domain.Users.Admins;

namespace Odyssey.Infrastructure.Common.Persistence.Configurations;

public class ApprovedAddHostRequestConfiguration : IEntityTypeConfiguration<ApprovedAddHostRequest>
{
    public void Configure(EntityTypeBuilder<ApprovedAddHostRequest> builder)
    {
        builder.ToTable("ApprovedAddHostRequests");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).ValueGeneratedOnAdd();

        builder.Property(a => a.HostId).IsRequired();
        builder.Property(a => a.ApprovedAdminId).IsRequired();

        builder.HasOne(a => a.host)
            .WithMany()
            .HasForeignKey(a => a.HostId)
            .HasPrincipalKey(h => h.Id)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.ApprovedAdmin)
            .WithMany()
            .HasForeignKey(a => a.ApprovedAdminId)
            .HasPrincipalKey(a => a.Id)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
