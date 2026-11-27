using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Odyssey.Domain.Hosts;
using Odyssey.Domain.Users.Owners;

namespace Odyssey.Infrastructure.Common.Persistence.Configurations;

public class HostConfiguration : IEntityTypeConfiguration<Host>
{
    public void Configure(EntityTypeBuilder<Host> builder)
    {
        builder.ToTable("Hosts");
        builder.HasKey(h => h.Id);
        builder.Property(h => h.Id).ValueGeneratedOnAdd();

        builder.Property(h => h.OwnerUserName).IsRequired().HasMaxLength(200);
        builder.Property(h => h.Description).HasMaxLength(1000);

        builder.HasOne(h => h.Owner)
            .WithMany()
            .HasForeignKey(h => h.OwnerUserName)
            .HasPrincipalKey(o => o.UserName)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
