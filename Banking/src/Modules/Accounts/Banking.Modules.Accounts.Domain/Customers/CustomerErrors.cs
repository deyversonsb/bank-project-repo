using Banking.Common.Domain;

namespace Banking.Modules.Accounts.Domain.Customers;
public static class CustomerErrors
{
    public static Error NotFound(Guid customerId)
        => Error.NotFound("Customers.NotFound", $"The customer with the identifier {customerId} was not found.");

    public static readonly Error InitialCreditLessThanZero = Error.Problem(
        "Customers.InitialCreditLessThanZero",
        "The initial credit must not be less than 0.");
}
