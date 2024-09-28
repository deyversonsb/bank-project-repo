using Banking.Common.Application.Exceptions;
using Banking.Common.Domain;
using Banking.Modules.Accounts.IntegrationEvents;
using Banking.Modules.Transactions.Application.Customers.CreateCustomer;
using MassTransit;
using MediatR;

namespace Banking.Modules.Transactions.Presentation.Customers;
public sealed class CustomerCreatedIntegrationEventConsumer(
    ISender sender) : IConsumer<CustomerCreatedIntegrationEvent>
{
    public async Task Consume(ConsumeContext<CustomerCreatedIntegrationEvent> context)
    {
        Result result = await sender.Send(new CreateCustomerCommand(
            context.Message.CustomerId,
            context.Message.Name,
            context.Message.Surname,
            context.Message.CreatedAtUtc,
            context.Message.InitialCredit));

        if (result.IsFailure)
        {
            throw new BankingException(nameof(CreateCustomerCommand), result.Error);
        }
    }
}
