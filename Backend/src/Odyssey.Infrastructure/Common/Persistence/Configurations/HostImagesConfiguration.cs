using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Odyssey.Domain.Hosts;

namespace Odyssey.Infrastructure.Common.Persistence.Configurations;

public class HostImagesConfiguration : IEntityTypeConfiguration<HostImages>
{
    public void Configure(EntityTypeBuilder<HostImages> builder)
    {
        builder.ToTable("HostImages");
        builder.HasKey(hi => hi.Id);
        builder.Property(hi => hi.Id).ValueGeneratedOnAdd();

        // ImageKey is nullable.
        builder.Property(hi => hi.ImageKey).HasMaxLength(1000);

        builder.Property(hi => hi.HostId).IsRequired();

        builder.HasOne(hi => hi.Host)
            .WithMany(h => h.HostImages)
            .HasForeignKey(hi => hi.HostId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
