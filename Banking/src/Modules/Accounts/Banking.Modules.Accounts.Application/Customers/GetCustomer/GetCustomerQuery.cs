using Banking.Common.Application.Messaging;

namespace Banking.Modules.Accounts.Application.Customers.GetCustomer;
public sealed record GetCustomerQuery(Guid CustomerId) : IQuery<CustomerResponse>;
