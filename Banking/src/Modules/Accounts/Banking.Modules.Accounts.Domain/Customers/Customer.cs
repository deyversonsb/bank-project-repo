using Banking.Common.Domain;

namespace Banking.Modules.Accounts.Domain.Customers;
public sealed class Customer : Entity
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public DateTime CreatedAtUtc { get; private set; }
    public static Customer Create(string name, string surname, decimal initialCredit)
    {
        var customer = new Customer()
        {
            Id = Guid.NewGuid(),
            Name = name,
            Surname = surname,
            CreatedAtUtc = DateTime.UtcNow
        };

        customer.Raise(new CustomerCreatedDomainEvent(customer.Id, initialCredit));

        return customer;
    }

}
