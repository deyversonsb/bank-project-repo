using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking.Common.Application.Messaging;
using Banking.Common.Domain;
using Banking.Modules.Accounts.Domain.Customers;

namespace Banking.Modules.Accounts.Application.Customers.GetCustomer;
internal sealed class GetCustomerQueryHandler(
    ICustomerRepository customerRepository) : IQueryHandler<GetCustomerQuery, CustomerResponse>
{
    public async Task<Result<CustomerResponse>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        Customer? customer = await customerRepository.GetCustomerById(request.CustomerId);

        if (customer is null)
        {
            return Result.Failure<CustomerResponse>(CustomerErrors.NotFound(request.CustomerId));
        }

        return GetCustomerResponse(customer);
    }

    private static CustomerResponse GetCustomerResponse(Customer customer)
        => new(customer.Id, customer.Name, customer.Surname, customer.CreatedAtUtc);
    
}
