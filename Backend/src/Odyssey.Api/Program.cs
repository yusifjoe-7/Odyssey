using Odyssey.Application;
using Odyssey.Application.Common.Auth;
using Odyssey.Application.Common.Persistence.Interfaces;
using Odyssey.Domain.Users;
using Odyssey.Infrastructure;
using Odyssey.Infrastructure.Auth;
using Odyssey.Infrastructure.Common.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Odyssey.Api.Middleware;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CustomerOnly", policy =>
        policy.RequireRole(Role.Customer.ToString()));
    options.AddPolicy("OwnerOnly", policy =>
        policy.RequireRole(Role.Owner.ToString()));
    options.AddPolicy("AdminOnly", policy =>
        policy.RequireRole(Role.Admin.ToString()));
});

builder.Services.AddScoped<IConversationDb>(sp => sp.GetRequiredService<OdysseyDbContext>());
builder.Services.AddScoped<IMessageDb>(sp => sp.GetRequiredService<OdysseyDbContext>());
builder.Services.AddScoped<IHostDb>(sp => sp.GetRequiredService<OdysseyDbContext>());
builder.Services.AddScoped<IAddHostRequestDb>(sp => sp.GetRequiredService<OdysseyDbContext>());
builder.Services.AddScoped<IReservationDb>(sp => sp.GetRequiredService<OdysseyDbContext>());
builder.Services.AddScoped<ICustomerReviewDb>(sp => sp.GetRequiredService<OdysseyDbContext>());
builder.Services.AddScoped<IHostReviewDb>(sp => sp.GetRequiredService<OdysseyDbContext>());
builder.Services.AddScoped<IOwnerReviewDb>(sp => sp.GetRequiredService<OdysseyDbContext>());
builder.Services.AddScoped<IIssueDb>(sp => sp.GetRequiredService<OdysseyDbContext>());
builder.Services.AddScoped<IAdminDb>(sp => sp.GetRequiredService<OdysseyDbContext>());
builder.Services.AddScoped<ICreateAdminRequestDb>(sp => sp.GetRequiredService<OdysseyDbContext>());
builder.Services.AddScoped<ICustomerDb>(sp => sp.GetRequiredService<OdysseyDbContext>());
builder.Services.AddScoped<IOwnerDb>(sp => sp.GetRequiredService<OdysseyDbContext>());




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

await app.Services.ApplyMigrationsAsync();

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
