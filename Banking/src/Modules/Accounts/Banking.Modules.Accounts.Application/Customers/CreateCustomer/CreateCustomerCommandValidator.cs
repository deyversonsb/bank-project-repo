using FluentValidation;

namespace Banking.Modules.Accounts.Application.Customers.CreateCustomer;
internal sealed class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Surname).NotEmpty();
        RuleFor(c => c.InitialCredit).GreaterThanOrEqualTo(0);

    }
}
