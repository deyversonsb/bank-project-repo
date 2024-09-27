using Banking.Common.Application.Messaging;

namespace Banking.Modules.Transactions.Application.Transactions.GetTransaction;
public sealed record GetTransactionQuery(Guid TransactionId) : IQuery<TransactionResponse>;
