using Banking.Common.Domain;

namespace Banking.Modules.Transactions.Domain.Customers;
public sealed class Customer : Entity
{
    private Customer() { }
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public DateTime CreatedAtUtc { get; private set; }

    public static Customer Create(Guid id, string name, string surname, DateTime createdAtUtc)
        => new()
        {
            Id = id,
            Name = name,
            Surname = surname,
            CreatedAtUtc = createdAtUtc
        };
}
