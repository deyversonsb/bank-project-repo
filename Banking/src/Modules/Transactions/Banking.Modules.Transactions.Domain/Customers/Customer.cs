using Banking.Common.Domain;

namespace Banking.Modules.Transactions.Domain.Customers;
public sealed class Customer : Entity
{
    private Customer() { }
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Surname { get; private set; }

    public static Customer Create(Guid id, string name, string surname, decimal initialCredit)
    {
        var customer = new Customer
        {
            Id = id,
            Name = name,
            Surname = surname
        };

        if (initialCredit > 0)
        {
            customer.Raise(new CustomerInitialCreditedDomainEvent(customer.Id, initialCredit));
        }

        customer.Raise(new CustomerCreatedDomainEvent(customer.Id));

        return customer;
    }
}
