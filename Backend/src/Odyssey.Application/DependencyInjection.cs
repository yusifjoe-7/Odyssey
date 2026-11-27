
using Odyssey.Application.Users.Admins.Registering;
using Odyssey.Application.Users.Owners.Registering;
using Odyssey.Application.Users.Customers.Registering;
namespace Odyssey.Application;

using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Odyssey.Application.Behavior;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

            services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        

        services.AddScoped<CustomerDbRegisteringCommit>();
        services.AddScoped<OwnerDbRegisteringCommit>();
        services.AddScoped<AdminDbRegisteringCommit>();
        
        services.AddScoped<CheckNameAndEmailCustomer>();
        services.AddScoped<CheckNameAndEmailOwner>();
        services.AddScoped<CheckNameAndEmailAdmin>();

        return services;
    }
}
