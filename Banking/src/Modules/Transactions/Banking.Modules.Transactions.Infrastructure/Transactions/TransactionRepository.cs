using Banking.Modules.Transactions.Domain.Transactions;

namespace Banking.Modules.Transactions.Infrastructure.Transactions;
internal sealed class TransactionRepository(
    TransactionDbContext context) : ITransactionRepository
{
    public void InitialCredit(Transaction transaction)
        => context.Transactions.Add(transaction);

    public async Task<Transaction?> GetTransactionById(Guid transactionId)
        => await context.Transactions.FindAsync(transactionId);
}
