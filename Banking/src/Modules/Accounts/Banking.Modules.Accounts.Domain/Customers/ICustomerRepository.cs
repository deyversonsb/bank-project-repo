namespace Banking.Modules.Accounts.Domain.Customers;
public interface ICustomerRepository
{
    Task<Customer?> GetCustomerById(Guid customerId);
    void Insert(Customer customer);
}
