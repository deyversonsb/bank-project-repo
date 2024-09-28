using FluentValidation;

namespace Banking.Modules.Accounts.Application.Customers.GetCustomer;
internal sealed class GetCustomerQueryValidator : AbstractValidator<GetCustomerQuery>
{
    public GetCustomerQueryValidator()
    {
        RuleFor(c => c.CustomerId).NotEmpty();
    }
}
