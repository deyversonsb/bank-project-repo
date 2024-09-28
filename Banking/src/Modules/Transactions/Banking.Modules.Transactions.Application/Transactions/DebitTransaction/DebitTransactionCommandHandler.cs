using Banking.Common.Application.Messaging;
using Banking.Common.Domain;
using Banking.Modules.Transactions.Application.Abstractions.Data;
using Banking.Modules.Transactions.Domain.Customers;
using Banking.Modules.Transactions.Domain.Transactions;

namespace Banking.Modules.Transactions.Application.Transactions.DebitTransaction;
internal sealed class DebitTransactionCommandHandler(
    ITransactionRepository transactionRepository,
    ICustomerRepository customerRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<DebitTransactionCommand, Guid>
{
    public async Task<Result<Guid>> Handle(DebitTransactionCommand request, CancellationToken cancellationToken)
    {
        Customer? customer = await customerRepository.GetCustomerById(request.CustomerId);

        if (customer is null)
        {
            return Result.Failure<Guid>(CustomerErrors.NotFound(request.CustomerId));
        }

        var transaction = Transaction.Create(request.CustomerId);

        transaction.Debit(request.DebitValue);

        transactionRepository.Insert(transaction);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return transaction.Id;
    }
}
