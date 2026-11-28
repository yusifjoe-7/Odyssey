using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Odyssey.Domain.Hosts;
using Odyssey.Domain.Users.Owners;

namespace Odyssey.Infrastructure.Common.Persistence.Configurations;

public class AddHostRequestConfiguration : IEntityTypeConfiguration<AddHostRequest>
{
    public void Configure(EntityTypeBuilder<AddHostRequest> builder)
    {
        builder.ToTable("AddHostRequests");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).ValueGeneratedOnAdd();

        builder.Property(a => a.OwnerUserName).IsRequired().HasMaxLength(200);
        builder.Property(a => a.Description).HasMaxLength(1000);
        builder.Property(a => a.Situation).IsRequired();

        builder.HasOne(a => a.Owner)
            .WithMany()
            .HasForeignKey(a => a.OwnerUserName)
            .HasPrincipalKey(o => o.UserName)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(a => a.HostImages)
            .WithOne()
            .HasForeignKey("AddHostRequestId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
