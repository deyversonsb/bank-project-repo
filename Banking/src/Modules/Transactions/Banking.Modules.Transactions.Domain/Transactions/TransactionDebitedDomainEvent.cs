using Banking.Common.Domain;

namespace Banking.Modules.Transactions.Domain.Transactions;
public sealed class TransactionDebitedDomainEvent(
    Guid transactionId,
    Guid customerId,
    decimal amount,
    DateTime createdAtUtc) : DomainEvent
{
    public Guid TransactionId { get; init; } = transactionId;
    public Guid CustomerId { get; init; } = customerId;
    public decimal Amount { get; init; } = amount;
    public DateTime CreatedAtUtc { get; set; } = createdAtUtc;
}
