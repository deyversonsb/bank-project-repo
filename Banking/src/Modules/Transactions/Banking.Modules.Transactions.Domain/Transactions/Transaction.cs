using Banking.Common.Domain;

namespace Banking.Modules.Transactions.Domain.Transactions;

public sealed class Transaction : Entity
{
    private Transaction() { }
    public Guid Id { get; private set; }
    public decimal Amount { get; private set; }
    public TransactionType TransactionType { get; private set; }
    public DateTime CreatedAtUtc { get; private set; }
    public Guid CustomerId { get; private set; }
    public static Result<Transaction> Create(
        Guid customerId,
        decimal amount)
    {
        if (amount < 0)
        {
            return Result.Failure<Transaction>(TransactionErrors.AmountLessThanZero);
        }

        var transaction = new Transaction
        {
            Id = Guid.NewGuid(),
            CustomerId = customerId,
            Amount = amount,
            TransactionType = TransactionType.Credit,
            CreatedAtUtc = DateTime.UtcNow
        };

        transaction.Raise(new TransactionCreatedDomainEvent(transaction.Id));

        return transaction;
    }

    public Result Credit(decimal amount)
    {
        if (amount < 0)
        {
            return Result.Failure(TransactionErrors.AmountLessThanZero);
        }

        Amount += amount;
        CreatedAtUtc = DateTime.UtcNow;

        Raise(new TransactionCreditedDomainEvent(Id, Amount, CreatedAtUtc));

        return Result.Success();
    }

    public Result Debit(decimal amount)
    {
        if (amount < 0)
        {
            return Result.Failure(TransactionErrors.AmountLessThanZero);
        }

        Amount -= amount;
        CreatedAtUtc = DateTime.UtcNow;

        Raise(new TransactionDebitedDomainEvent(Id, Amount, CreatedAtUtc));

        return Result.Success();
    }

}
