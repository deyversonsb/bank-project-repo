using Banking.Common.Application.Messaging;
using Banking.Common.Domain;
using Banking.Modules.Transactions.Application.Abstractions.Data;
using Banking.Modules.Transactions.Domain.Customers;
using Banking.Modules.Transactions.Domain.Transactions;
using MediatR;

namespace Banking.Modules.Transactions.Application.Customers.CreateCustomer;
internal sealed class CreateCustomerCommandHandler(
    ICustomerRepository customerRepository,
    ITransactionRepository transactionRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<CreateCustomerCommand>
{
    public async Task<Result> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = Customer.Create(
            request.Id,
            request.Name,
            request.Surname,
            request.CreatedAtUtc);

        customerRepository.Insert(customer);

        if (request.InitialCredit > 0)
        {
            Result<Transaction> transaction = Transaction.Create(customer.Id, request.InitialCredit);
            transactionRepository.Insert(transaction.Value);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
