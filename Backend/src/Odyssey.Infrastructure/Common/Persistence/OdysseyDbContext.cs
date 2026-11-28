
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
    IReservationDb,
    ICustomerReviewDb,
    IHostReviewDb,
    IOwnerReviewDb,
    IIssueDb,
    IAdminDb,
    ICreateAdminRequestDb,
    ICustomerDb,
    IOwnerDb,
    IRefreshTokenDb,
    IUserDb
{
    public OdysseyDbContext(DbContextOptions<OdysseyDbContext> options) : base(options) { }

    public DbSet<Conversation> Conversations => Set<Conversation>();
    public DbSet<Message> Messages => Set<Message>();

    public DbSet<Host> Hosts => Set<Host>();
    public DbSet<HostImages> HostImages => Set<HostImages>();
    public DbSet<AddHostRequest> AddHostRequests => Set<AddHostRequest>();

    public DbSet<Reservation> Reservations => Set<Reservation>();

    public DbSet<CustomerReview> CustomerReviews => Set<CustomerReview>();
    public DbSet<HostReview> HostReviews => Set<HostReview>();
    public DbSet<OwnerReview> OwnerReviews => Set<OwnerReview>();

    public DbSet<Issue> Issues => Set<Issue>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

    public DbSet<Admin> Admins => Set<Admin>();
    public DbSet<CreateAdminRequest> CreateAdminRequests => Set<CreateAdminRequest>();

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Owner> Owners => Set<Owner>();

    public async Task<User?> FindUserByUserNameAsync(string userName, CancellationToken cancellationToken = default)
    {
        // User hierarchy uses TPC; no single Users table, so search each concrete table.
        User? user = await Admins.FirstOrDefaultAsync(u => u.UserName == userName, cancellationToken);
        if (user is not null) return user;

        user = await Customers.FirstOrDefaultAsync(u => u.UserName == userName, cancellationToken);
        if (user is not null) return user;

        return await Owners.FirstOrDefaultAsync(u => u.UserName == userName, cancellationToken);
    }

    public async Task<User?> FindUserAsync(int userId, CancellationToken cancellationToken = default)
    {
        // User hierarchy uses TPC; no single Users table, so search each concrete table.
        User? user = await Admins.FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
        if (user is not null) return user;

        user = await Customers.FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
        if (user is not null) return user;

        return await Owners.FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<User>();
        modelBuilder.Ignore<Client>();
        modelBuilder.Ignore<Review>();

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OdysseyDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}