using Banking.Common.Infrastructure.Interceptors;
using Banking.Common.Presentation.Endpoints;
using Banking.Modules.Accounts.Application.Abstractions;
using Banking.Modules.Accounts.Domain.Customers;
using Banking.Modules.Accounts.Infrastructure.Customers;
using Banking.Modules.Accounts.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Banking.Modules.Accounts.Infrastructure;
public static class AccountsModule
{
    public static IServiceCollection AddAccountsModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddEndpoints(Presentation.AssemblyReference.Assembly);

        services.AddInfrastructure(configuration);

        return services;
    }

    private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string databaseConnectionString = configuration.GetConnectionString("Database")!;

        services.AddDbContext<AccountsDbContext>((sp, options) => 
            options.UseInMemoryDatabase(databaseConnectionString)
                   .AddInterceptors(sp.GetRequiredService<PublishDomainEventsInterceptor>()));

        services.AddScoped<ICustomerRepository, CustomerRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<AccountsDbContext>());
    }
}
