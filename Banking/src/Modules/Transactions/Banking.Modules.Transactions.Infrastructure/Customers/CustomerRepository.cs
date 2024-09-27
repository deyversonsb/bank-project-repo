using Banking.Modules.Transactions.Domain.Customers;

namespace Banking.Modules.Transactions.Infrastructure.Customers;
internal sealed class CustomerRepository(
    TransactionDbContext context) : ICustomerRepository
{
    public async Task<Customer?> GetCustomerById(Guid customerId)
        => await context.Customers.FindAsync(customerId);

    public void Insert(Customer customer)
        => context.Customers.Add(customer);
}
