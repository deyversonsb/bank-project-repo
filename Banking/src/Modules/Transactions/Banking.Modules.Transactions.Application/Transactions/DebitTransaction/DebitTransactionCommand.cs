using Banking.Common.Application.Messaging;

namespace Banking.Modules.Transactions.Application.Transactions.DebitTransaction;
public sealed record DebitTransactionCommand(Guid CustomerId, decimal DebitValue) : ICommand<Guid>;
