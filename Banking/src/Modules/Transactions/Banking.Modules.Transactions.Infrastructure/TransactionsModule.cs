using Banking.Common.Infrastructure.Interceptors;
using Banking.Common.Presentation.Endpoints;
using Banking.Modules.Transactions.Application.Abstractions.Data;
using Banking.Modules.Transactions.Domain.Customers;
using Banking.Modules.Transactions.Domain.Transactions;
using Banking.Modules.Transactions.Infrastructure.Customers;
using Banking.Modules.Transactions.Infrastructure.Transactions;
using Banking.Modules.Transactions.Presentation.Customers;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Banking.Modules.Transactions.Infrastructure;
public static class TransactionsModule
{
    public static IServiceCollection AddTransactionsModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddEndpoints(Presentation.AssemblyReference.Assembly);

        services.AddInfrastructure(configuration);

        return services;
    }

    public static void ConfigureConsumers(IRegistrationConfigurator registrationConfigurator)
    {
        registrationConfigurator.AddConsumer<CustomerCreatedIntegrationEventConsumer>();
    }
    private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string databaseConnectionString = configuration.GetConnectionString("Database")!;

        services.AddDbContext<TransactionDbContext>((sp, options) =>
            options.UseInMemoryDatabase(databaseConnectionString)
                   .AddInterceptors(sp.GetRequiredService<PublishDomainEventsInterceptor>()));

        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<TransactionDbContext>());
    }
}
