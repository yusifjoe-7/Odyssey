using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Odyssey.Domain.Reviews.Customers;
using Odyssey.Domain.Users.Customers;

namespace Odyssey.Infrastructure.Common.Persistence.Configurations;

public class CustomerReviewConfiguration : IEntityTypeConfiguration<CustomerReview>
{
    public void Configure(EntityTypeBuilder<CustomerReview> builder)
    {
        builder.ToTable("CustomerReviews");
        builder.HasKey(cr => cr.Id);
        builder.Property(cr => cr.Id).ValueGeneratedOnAdd();

        // The Review base type is excluded from the model, so map its properties explicitly.
        builder.Property(cr => cr.UserName).IsRequired().HasMaxLength(200);
        builder.Property(cr => cr.Rate).IsRequired();
        builder.Property(cr => cr.Description).HasMaxLength(1000);

        builder.Property(cr => cr.ToCustomerUserName).IsRequired().HasMaxLength(200);

        builder.HasOne(cr => cr.ToCustomer)
            .WithMany()
            .HasForeignKey(cr => cr.ToCustomerUserName)
            .HasPrincipalKey(cu => cu.UserName)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
