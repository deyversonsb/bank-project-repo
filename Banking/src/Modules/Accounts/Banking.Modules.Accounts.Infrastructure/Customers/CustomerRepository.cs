using Banking.Modules.Accounts.Domain.Customers;
using Banking.Modules.Accounts.Infrastructure.Database;

namespace Banking.Modules.Accounts.Infrastructure.Customers;
internal sealed class CustomerRepository(
    AccountsDbContext context) : ICustomerRepository
{
    public async Task<Customer?> GetCustomerById(Guid customerId)
        => await context.Customers.FindAsync(customerId);

    public void Insert(Customer customer)
        => context.Customers.Add(customer);
}
