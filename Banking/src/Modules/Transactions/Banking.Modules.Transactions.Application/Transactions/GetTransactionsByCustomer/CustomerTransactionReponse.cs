namespace Banking.Modules.Transactions.Application.Transactions.GetTransactionsByCustomer;
public sealed record CustomerTransactionReponse(
    Guid CustomerId,
    string Name,
    string Surname,
    decimal Balance)
{
    public List<TransactionResponse> Transactions { get; set; }
}
