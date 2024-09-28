using FluentValidation;

namespace Banking.Modules.Transactions.Application.Customers.CreateCustomer;
internal sealed class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
