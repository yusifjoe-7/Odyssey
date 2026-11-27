using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Odyssey.Domain.Hosts;
using Odyssey.Domain.Reservations;
using Odyssey.Domain.Users.Customers;
using Odyssey.Domain.Users.Owners;

namespace Odyssey.Infrastructure.Common.Persistence.Configurations;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.ToTable("Reservations");
        builder.HasKey(r => r.Id);
        // The domain supplies the Guid (e.g. for support reports), so do not generate it in the database.
        builder.Property(r => r.Id).ValueGeneratedNever();

        builder.Property(r => r.OwnerUserName).IsRequired().HasMaxLength(200);
        builder.Property(r => r.CustomerUserName).IsRequired().HasMaxLength(200);
        builder.Property(r => r.HostId).IsRequired();
        builder.Property(r => r.From).IsRequired();
        builder.Property(r => r.To).IsRequired();

        builder.Property(r => r.TotalPrice)
            .HasColumnName("decimal(10, 1)")
            .IsRequired();

        builder.HasOne(r => r.Owner)
            .WithMany()
            .HasForeignKey(r => r.OwnerUserName)
            .HasPrincipalKey(o => o.UserName)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.customer)
            .WithMany()
            .HasForeignKey(r => r.CustomerUserName)
            .HasPrincipalKey(cu => cu.UserName)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.host)
            .WithMany()
            .HasForeignKey(r => r.HostId)
            .HasPrincipalKey(h => h.Id)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
