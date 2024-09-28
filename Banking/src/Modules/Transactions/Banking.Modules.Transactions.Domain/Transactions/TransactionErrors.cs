using Banking.Common.Domain;

namespace Banking.Modules.Transactions.Domain.Transactions;
public static class TransactionErrors
{
    public static Error NotFound(Guid transactionId)
        => Error.NotFound("Transactions.NotFound", $"The transaction with the identifier {transactionId} was not found.");

    public static readonly Error AmountLessThanOrEqualZero = Error.Problem(
        "Transactions.AmountLessThanZero",
        "The amount must be greater than 0.");
}
