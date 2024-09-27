using Banking.Common.Domain;

namespace Banking.Modules.Transactions.Domain.Transactions;
public sealed class TransactionCreatedDomainEvent(Guid transactionId) : DomainEvent
{
    public Guid TransactionId { get; init; } = transactionId;
}
