using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Odyssey.Domain.Users.Admins;

namespace Odyssey.Infrastructure.Common.Persistence.Configurations;

public class CreateAdminRequestApprovedConfiguration : IEntityTypeConfiguration<CreateAdminRequestApproved>
{
    public void Configure(EntityTypeBuilder<CreateAdminRequestApproved> builder)
    {
        builder.ToTable("CreateAdminRequestsApproved");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();

        builder.Property(c => c.AdminId).IsRequired();
        builder.Property(c => c.ApprovedWithCode).IsRequired().HasMaxLength(200);

        builder.HasOne(c => c.admin)
            .WithMany()
            .HasForeignKey(c => c.AdminId)
            .HasPrincipalKey(a => a.Id)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
