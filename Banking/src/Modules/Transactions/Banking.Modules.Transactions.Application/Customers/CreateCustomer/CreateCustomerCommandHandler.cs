using Banking.Common.Application.Messaging;
using Banking.Common.Domain;
using Banking.Modules.Transactions.Application.Abstractions.Data;
using Banking.Modules.Transactions.Domain.Customers;

namespace Banking.Modules.Transactions.Application.Customers.CreateCustomer;
internal sealed class CreateCustomerCommandHandler(
    ICustomerRepository customerRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<CreateCustomerCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = Customer.Create(
            request.Id,
            request.Name,
            request.Surname,
            request.InitialCredit);

        customerRepository.Insert(customer);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return customer.Id;
    }
}
