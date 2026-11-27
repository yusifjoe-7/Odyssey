
using Microsoft.EntityFrameworkCore;
using Odyssey.Application.Common.Persistence.Interfaces;
using Odyssey.Domain.ChatSystem;
using Odyssey.Domain.Hosts;
using Odyssey.Domain.Reservations;
using Odyssey.Domain.Reviews;
using Odyssey.Domain.Reviews.Customers;
using Odyssey.Domain.Reviews.Hosts;
using Odyssey.Domain.Reviews.Owners;
using Odyssey.Domain.Support;
using Odyssey.Domain.Users;
using Odyssey.Domain.Users.Admins;
using Odyssey.Domain.Users.Customers;
using Odyssey.Domain.Users.Owners;

namespace Odyssey.Infrastructure.Common.Persistence;

public class OdysseyDbContext : DbContext,
    IConversationDb,
    IMessageDb,
    IHostDb,
    IAddHostRequestDb,
    IApprovedAddHostRequestDb,
    IReservationDb,
    ICustomerReviewDb,
    IHostReviewDb,
    IOwnerReviewDb,
    IIssueDb,
    IAdminDb,
    ICreateAdminRequestDb,
    ICreateAdminRequestApprovedDb,
    ICustomerDb,
    IOwnerDb
{
    public OdysseyDbContext(DbContextOptions<OdysseyDbContext> options) : base(options) { }

    public DbSet<Conversation> Conversations => Set<Conversation>();
    public DbSet<Message> Messages => Set<Message>();

    public DbSet<Host> Hosts => Set<Host>();
    public DbSet<AddHostRequest> AddHostRequests => Set<AddHostRequest>();
    public DbSet<ApprovedAddHostRequest> ApprovedAddHostRequests => Set<ApprovedAddHostRequest>();

    public DbSet<Reservation> Reservations => Set<Reservation>();

    public DbSet<CustomerReview> CustomerReviews => Set<CustomerReview>();
    public DbSet<HostReview> HostReviews => Set<HostReview>();
    public DbSet<OwnerReview> OwnerReviews => Set<OwnerReview>();

    public DbSet<Issue> Issues => Set<Issue>();

    public DbSet<Admin> Admins => Set<Admin>();
    public DbSet<CreateAdminRequest> CreateAdminRequests => Set<CreateAdminRequest>();
    public DbSet<CreateAdminRequestApproved> CreateAdminRequestsApproved => Set<CreateAdminRequestApproved>();

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Owner> Owners => Set<Owner>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<User>();
        modelBuilder.Ignore<Client>();
        modelBuilder.Ignore<Review>();

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OdysseyDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}