using Banking.Common.Domain;

namespace Banking.Modules.Transactions.Domain.Transactions;
public sealed class TransactionCreditedDomainEvent(
    Guid transactionId,
    decimal amount,
    DateTime createdAtUtc) : DomainEvent
{
    public Guid TransactionId { get; init; } = transactionId;
    public decimal Amount { get; init; } = amount;
    public DateTime CreatedAtUtc { get; set; } = createdAtUtc;
}
