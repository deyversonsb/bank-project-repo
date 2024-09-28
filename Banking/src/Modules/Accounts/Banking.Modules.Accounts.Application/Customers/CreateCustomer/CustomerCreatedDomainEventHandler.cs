using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking.Common.Application.EventBus;
using Banking.Common.Application.Exceptions;
using Banking.Common.Application.Messaging;
using Banking.Common.Domain;
using Banking.Modules.Accounts.Application.Customers.GetCustomer;
using Banking.Modules.Accounts.Domain.Customers;
using Banking.Modules.Accounts.IntegrationEvents;
using MediatR;

namespace Banking.Modules.Accounts.Application.Customers.CreateCustomer;
internal sealed class CustomerCreatedDomainEventHandler(
    ISender sender, IEventBus eventBus) : IDomainEventHandler<CustomerCreatedDomainEvent>
{
    public async Task Handle(CustomerCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        Result<CustomerResponse> result = await sender.Send(new GetCustomerQuery(notification.CustomerId), cancellationToken);

        if (result.IsFailure)
        {
            throw new BankingException(nameof(GetCustomerQuery), result.Error);
        }

        await eventBus.PublishAsync(
            new CustomerCreatedIntegrationEvent(
                notification.Id,
                notification.OccurredOnUtc,
                result.Value.Id,
                result.Value.Name,
                result.Value.Surname,
                result.Value.CreatedAtUtc,
                notification.InitialCredit),
            cancellationToken);
    }
}
