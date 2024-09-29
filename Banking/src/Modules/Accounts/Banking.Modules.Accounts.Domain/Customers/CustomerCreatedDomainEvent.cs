using Banking.Common.Domain;

namespace Banking.Modules.Accounts.Domain.Customers;
public class CustomerCreatedDomainEvent(Guid customerId, decimal initialCredit) : DomainEvent
{
    public Guid CustomerId { get; init; } = customerId;
    public decimal InitialCredit { get; init; } = initialCredit;
}
