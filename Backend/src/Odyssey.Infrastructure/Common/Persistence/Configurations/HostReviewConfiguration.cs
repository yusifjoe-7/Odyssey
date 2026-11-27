using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Odyssey.Domain.Hosts;
using Odyssey.Domain.Reviews.Hosts;

namespace Odyssey.Infrastructure.Common.Persistence.Configurations;

public class HostReviewConfiguration : IEntityTypeConfiguration<HostReview>
{
    public void Configure(EntityTypeBuilder<HostReview> builder)
    {
        builder.ToTable("HostReviews");
        builder.HasKey(hr => hr.Id);
        builder.Property(hr => hr.Id).ValueGeneratedOnAdd();

        // The Review base type is excluded from the model, so map its properties explicitly.
        builder.Property(hr => hr.UserName).IsRequired().HasMaxLength(200);
        builder.Property(hr => hr.Rate).IsRequired();
        builder.Property(hr => hr.Description).HasMaxLength(1000);

        builder.Property(hr => hr.ToId).IsRequired();

        builder.HasOne(hr => hr.ToHost)
            .WithMany()
            .HasForeignKey(hr => hr.ToId)
            .HasPrincipalKey(h => h.Id)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
