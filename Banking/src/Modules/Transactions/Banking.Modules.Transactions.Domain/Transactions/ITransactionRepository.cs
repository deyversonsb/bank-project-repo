namespace Banking.Modules.Transactions.Domain.Transactions;
public interface ITransactionRepository
{
    void Insert(Transaction transaction);
    Task<Transaction?> GetTransactionByIdAsync(Guid transactionId, CancellationToken cancellationToken = default);
    Task<List<Transaction>> GetTransactionsByCustomerAsync(Guid customerId, CancellationToken cancellationToken = default);
}
