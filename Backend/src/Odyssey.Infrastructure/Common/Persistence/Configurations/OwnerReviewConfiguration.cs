using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Odyssey.Domain.Reviews.Owners;
using Odyssey.Domain.Users.Owners;

namespace Odyssey.Infrastructure.Common.Persistence.Configurations;

public class OwnerReviewConfiguration : IEntityTypeConfiguration<OwnerReview>
{
    public void Configure(EntityTypeBuilder<OwnerReview> builder)
    {
        builder.ToTable("OwnerReviews");
        builder.HasKey(or => or.Id);
        builder.Property(or => or.Id).ValueGeneratedOnAdd();

        // The Review base type is excluded from the model, so map its properties explicitly.
        builder.Property(or => or.UserName).IsRequired().HasMaxLength(200);
        builder.Property(or => or.Rate).IsRequired();
        builder.Property(or => or.Description).HasMaxLength(1000);

        builder.Property(or => or.ToOwnerUserName).IsRequired().HasMaxLength(200);

        builder.HasOne(or => or.ToOwner)
            .WithMany()
            .HasForeignKey(or => or.ToOwnerUserName)
            .HasPrincipalKey(o => o.UserName)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
