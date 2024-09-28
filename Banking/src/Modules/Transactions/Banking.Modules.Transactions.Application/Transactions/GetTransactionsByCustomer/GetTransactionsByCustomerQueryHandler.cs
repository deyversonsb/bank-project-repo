using Banking.Common.Application.Messaging;
using Banking.Common.Domain;
using Banking.Modules.Transactions.Domain.Customers;
using Banking.Modules.Transactions.Domain.Transactions;

namespace Banking.Modules.Transactions.Application.Transactions.GetTransactionsByCustomer;
internal sealed class GetTransactionsByCustomerQueryHandler(
    ITransactionRepository transactionRepository,
    ICustomerRepository customerRepository) : IQueryHandler<GetTransactionsByCustomerQuery, CustomerTransactionReponse>
{
    public async Task<Result<CustomerTransactionReponse>> Handle(GetTransactionsByCustomerQuery request, CancellationToken cancellationToken)
    {
        Customer? customer = await customerRepository.GetCustomerById(request.CustomerId);

        if (customer is null)
        {
            return Result.Failure<CustomerTransactionReponse>(CustomerErrors.NotFound(request.CustomerId));
        }
        List<TransactionResponse> transactionsList = [];

        List<Transaction> transactions = await transactionRepository.GetTransactionsByCustomerAsync(request.CustomerId, cancellationToken);

        if (!transactions.Exists(t => t.CustomerId == request.CustomerId))
        {
            return new CustomerTransactionReponse(customer.Id, customer.Name, customer.Surname, 0) { Transactions = transactionsList };
        }

        CustomerTransactionReponse? result 
            = transactions.GroupBy(t => t.Customer, t => t, (key, value) => new { Customer = key, Transactions = value })
                          .Select(t => new CustomerTransactionReponse(t.Customer.Id, t.Customer.Name, t.Customer.Surname, GetBalanceTotal(t.Transactions.ToList()))
                          {
                              Transactions = [.. t.Transactions
                                                  .Select(t => new TransactionResponse(t.Id,
                                                                                       t.Amount, 
                                                                                       t.TransactionType, 
                                                                                       Enum.GetName(typeof(TransactionType), t.TransactionType) ?? string.Empty,
                                                                                       t.CreatedAtUtc))]
                          })
                          .FirstOrDefault();

        return result;
    }

    private static decimal GetBalanceTotal(List<Transaction> transactions)
    {
        decimal amountCredited = transactions.Where(t => t.TransactionType == TransactionType.Credit).Select(t => t.Amount).Sum();
        decimal amountDebited = transactions.Where(t => t.TransactionType == TransactionType.Debit).Select(t => t.Amount).Sum();

        return amountCredited - amountDebited;
    }
}
