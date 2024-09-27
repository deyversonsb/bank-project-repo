using Banking.Common.Domain;

namespace Banking.Modules.Transactions.Domain.Customers;
public sealed class CustomerInitialCreditedDomainEvent(
    Guid customerId, decimal initialCredit) : DomainEvent
{
    public Guid CustomerId { get; init; } = customerId;
    public decimal InitialCredit { get; init; } = initialCredit;
}
