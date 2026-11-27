using Odyssey.Application;
using Odyssey.Application.Common.Persistence.Interfaces;
using Odyssey.Infrastructure;
using Odyssey.Infrastructure.Common.Persistence;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);


builder.Services.AddScoped<IConversationDb>(sp => sp.GetRequiredService<OdysseyDbContext>());
builder.Services.AddScoped<IMessageDb>(sp => sp.GetRequiredService<OdysseyDbContext>());
builder.Services.AddScoped<IHostDb>(sp => sp.GetRequiredService<OdysseyDbContext>());
builder.Services.AddScoped<IAddHostRequestDb>(sp => sp.GetRequiredService<OdysseyDbContext>());
builder.Services.AddScoped<IApprovedAddHostRequestDb>(sp => sp.GetRequiredService<OdysseyDbContext>());
builder.Services.AddScoped<IReservationDb>(sp => sp.GetRequiredService<OdysseyDbContext>());
builder.Services.AddScoped<ICustomerReviewDb>(sp => sp.GetRequiredService<OdysseyDbContext>());
builder.Services.AddScoped<IHostReviewDb>(sp => sp.GetRequiredService<OdysseyDbContext>());
builder.Services.AddScoped<IOwnerReviewDb>(sp => sp.GetRequiredService<OdysseyDbContext>());
builder.Services.AddScoped<IIssueDb>(sp => sp.GetRequiredService<OdysseyDbContext>());
builder.Services.AddScoped<IAdminDb>(sp => sp.GetRequiredService<OdysseyDbContext>());
builder.Services.AddScoped<ICreateAdminRequestDb>(sp => sp.GetRequiredService<OdysseyDbContext>());
builder.Services.AddScoped<ICreateAdminRequestApprovedDb>(sp => sp.GetRequiredService<OdysseyDbContext>());
builder.Services.AddScoped<ICustomerDb>(sp => sp.GetRequiredService<OdysseyDbContext>());
builder.Services.AddScoped<IOwnerDb>(sp => sp.GetRequiredService<OdysseyDbContext>());




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

await app.Services.ApplyMigrationsAsync();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
