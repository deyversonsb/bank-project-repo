namespace Banking.Modules.Accounts.Application.Customers.GetCustomer;
public sealed record CustomerResponse(
    Guid Id,
    string Name,
    string Surname,
    DateTime CreatedAtUtc);
