using Banking.Common.Application.Messaging;

namespace Banking.Modules.Accounts.Application.Customers.CreateCustomer;
public sealed record CreateCustomerCommand(
    string Name,
    string Surname,
    decimal InitialCredit) : ICommand<Guid>;
