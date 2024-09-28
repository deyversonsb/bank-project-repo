using Banking.Common.Application.Messaging;
using Banking.Common.Domain;
using Banking.Modules.Transactions.Domain.Transactions;


namespace Banking.Modules.Transactions.Application.Transactions.GetTransaction;
internal sealed class GetTransactionQueryHandler(
    ITransactionRepository transactionRepository) : IQueryHandler<GetTransactionQuery, TransactionResponse>
{
    public async Task<Result<TransactionResponse>> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
    {
        Transaction? transaction = await transactionRepository.GetTransactionByIdAsync(request.TransactionId, cancellationToken);

        if (transaction is null)
        {
            return Result.Failure<TransactionResponse>(TransactionErrors.NotFound(request.TransactionId));
        }

        return Result.Success(GetTransactionResponse(transaction));
    }
    private static TransactionResponse GetTransactionResponse(Transaction transaction)
        => new(
            transaction.Id,
            transaction.CustomerId,
            transaction.Amount,
            transaction.TransactionType,
            transaction.CreatedAtUtc)
        {
           Customer = new(transaction.Customer.Name, transaction.Customer.Surname)
        };
}
