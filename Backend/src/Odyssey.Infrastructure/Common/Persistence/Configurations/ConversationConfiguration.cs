using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Odyssey.Domain.ChatSystem;
using Odyssey.Domain.Reservations;
using Odyssey.Domain.Users.Customers;
using Odyssey.Domain.Users.Owners;

namespace Odyssey.Infrastructure.Common.Persistence.Configurations;

public class ConversationConfiguration : IEntityTypeConfiguration<Conversation>
{
    public void Configure(EntityTypeBuilder<Conversation> builder)
    {
        builder.ToTable("Conversations");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();

        builder.Property(c => c.CustomerId).IsRequired();
        builder.Property(c => c.OwnerId).IsRequired();
        builder.Property(c => c.ReservationId).IsRequired();

        builder.HasOne(c => c.customer)
            .WithMany()
            .HasForeignKey(c => c.CustomerId)
            .HasPrincipalKey(cu => cu.Id)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.owner)
            .WithMany()
            .HasForeignKey(c => c.OwnerId)
            .HasPrincipalKey(o => o.Id)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.Reservation)
            .WithMany()
            .HasForeignKey(c => c.ReservationId)
            .HasPrincipalKey(r => r.Id)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
