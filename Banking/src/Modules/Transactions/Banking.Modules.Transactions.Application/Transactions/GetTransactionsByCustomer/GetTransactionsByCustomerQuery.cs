using Banking.Common.Application.Messaging;
using Banking.Modules.Transactions.Application.Transactions.GetTransactionsByCustomer;

namespace Banking.Modules.Transactions.Application.Transactions.GetTransactionsByCustomer;
public sealed record GetTransactionsByCustomerQuery(Guid CustomerId) : IQuery<CustomerTransactionReponse>;
