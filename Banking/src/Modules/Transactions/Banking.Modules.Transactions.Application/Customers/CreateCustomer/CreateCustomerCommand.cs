using Banking.Common.Application.Messaging;

namespace Banking.Modules.Transactions.Application.Customers.CreateCustomer;
public sealed record CreateCustomerCommand(
    Guid Id,
    string Name,
    string Surname,
    DateTime CreatedAtUtc,
    decimal InitialCredit) : ICommand;
