using FluentValidation;

namespace Banking.Modules.Transactions.Application.Transactions.GetTransactionsByCustomer;
internal sealed class GetTransactionsByCustomerQueryValidator : AbstractValidator<GetTransactionsByCustomerQuery>
{
    public GetTransactionsByCustomerQueryValidator()
    {
        RuleFor(t => t.CustomerId).NotEmpty();
    }
}
