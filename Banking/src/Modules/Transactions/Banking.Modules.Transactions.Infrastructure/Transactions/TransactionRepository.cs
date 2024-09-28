using Banking.Modules.Transactions.Domain.Transactions;
using Microsoft.EntityFrameworkCore;

namespace Banking.Modules.Transactions.Infrastructure.Transactions;
internal sealed class TransactionRepository(
    TransactionDbContext context) : ITransactionRepository
{
    public void Insert(Transaction transaction)
        => context.Transactions.Add(transaction);

    public async Task<Transaction?> GetTransactionByIdAsync(Guid transactionId, CancellationToken cancellationToken = default)
        => await context.Transactions
                        .Include(t => t.Customer)
                        .FirstOrDefaultAsync(t => t.Id == transactionId, cancellationToken);

    public async Task<List<Transaction>> GetTransactionsByCustomerAsync(Guid customerId, CancellationToken cancellationToken = default)
        => await context.Transactions
                        .Include(t => t.Customer)
                        .Where(t => t.CustomerId == customerId)
                        .OrderByDescending(t => t.CreatedAtUtc)
                        .ToListAsync(cancellationToken);
}
