using Banking.Common.Application.Messaging;

namespace Banking.Modules.Transactions.Application.Transactions.CreditTransaction;
public sealed record CreditTransactionCommand(
    Guid CustomerId,
    decimal InitialCredit) : ICommand<Guid>;
