using Banking.Common.Application.Messaging;
using Banking.Common.Domain;
using Banking.Modules.Transactions.Domain.Transactions;


namespace Banking.Modules.Transactions.Application.Transactions.GetTransaction;
internal sealed class GetTransactionQueryHandler
    (ITransactionRepository transactionRepository) : IQueryHandler<GetTransactionQuery, TransactionResponse>
{
    public async Task<Result<TransactionResponse>> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
    {
        Transaction? transaction = await transactionRepository.GetTransactionById(request.TransactionId);

        if (transaction is null)
        {
            return Result.Failure<TransactionResponse>(TransactionErrors.NotFound(request.TransactionId));
        }


        return Result.Success<TransactionResponse>(
                   new(transaction.Id,
                       transaction.CustomerId,
                       transaction.Amount,
                       transaction.TransactionType,
                       transaction.CreatedAtUtc));
    }
}
