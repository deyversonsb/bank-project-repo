namespace Banking.Modules.Transactions.Application.Abstractions.Data;
public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
