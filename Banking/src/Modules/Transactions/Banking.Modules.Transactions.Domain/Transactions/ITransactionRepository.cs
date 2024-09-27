namespace Banking.Modules.Transactions.Domain.Transactions;
public interface ITransactionRepository
{
    void InitialCredit(Transaction transaction);
    Task<Transaction?> GetTransactionById(Guid transactionId);
}
