using Banking.Modules.Transactions.Domain.Transactions;

namespace Banking.Modules.Transactions.Application.Transactions.GetTransaction;
public sealed record TransactionResponse(
    Guid Id,
    Guid CustomerId,
    decimal Amount,
    TransactionType TransactionType,
    DateTime CreatedAtUtc);
