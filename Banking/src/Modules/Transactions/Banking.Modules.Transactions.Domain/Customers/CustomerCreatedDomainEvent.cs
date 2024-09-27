using Banking.Common.Domain;

namespace Banking.Modules.Transactions.Domain.Customers;
public sealed class CustomerCreatedDomainEvent(Guid customerId) : DomainEvent
{
    public Guid CustomerId { get; init; } = customerId;
}
