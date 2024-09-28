using Banking.Modules.Transactions.Application.Abstractions.Data;
using Banking.Common.Application.Messaging;
using Banking.Common.Domain;
using Banking.Modules.Transactions.Domain.Customers;
using Banking.Modules.Transactions.Domain.Transactions;

namespace Banking.Modules.Transactions.Application.Transactions.CreditTransaction;
internal sealed class CreditTransactionCommandHandler(
    ITransactionRepository transactionRepository,
    ICustomerRepository customerRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<CreditTransactionCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreditTransactionCommand request, CancellationToken cancellationToken)
    {
        Customer? customer = await customerRepository.GetCustomerById(request.CustomerId);

        if (customer is null)
        {
            return Result.Failure<Guid>(CustomerErrors.NotFound(request.CustomerId));
        }

        Result<Transaction> result = Transaction.Create(
            request.CustomerId,
            request.InitialCredit);

        if (result.IsFailure)
        {
            return Result.Failure<Guid>(result.Error);
        }

        transactionRepository.Insert(result.Value);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return result.Value.Id;
    }
}
