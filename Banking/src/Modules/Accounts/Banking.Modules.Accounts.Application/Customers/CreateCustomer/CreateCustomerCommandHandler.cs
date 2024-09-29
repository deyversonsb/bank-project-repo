using Banking.Common.Application.Messaging;
using Banking.Common.Domain;
using Banking.Modules.Accounts.Application.Abstractions;
using Banking.Modules.Accounts.Domain.Customers;

namespace Banking.Modules.Accounts.Application.Customers.CreateCustomer;
internal sealed class CreateCustomerCommandHandler(
    ICustomerRepository customerRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<CreateCustomerCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        Result<Customer> result = Customer.Create(request.Name, request.Surname, request.InitialCredit);

        if (result.IsFailure)
        {
            return Result.Failure<Guid>(result.Error);
        }

        customerRepository.Insert(result.Value);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return result.Value.Id;
    }
}
