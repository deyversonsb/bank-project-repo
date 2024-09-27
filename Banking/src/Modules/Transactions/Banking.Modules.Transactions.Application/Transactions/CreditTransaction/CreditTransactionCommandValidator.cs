using FluentValidation;

namespace Banking.Modules.Transactions.Application.Transactions.CreditTransaction;
internal sealed class CreditTransactionCommandValidator : AbstractValidator<CreditTransactionCommand>
{
    public CreditTransactionCommandValidator()
    {
        RuleFor(t => t.CustomerId).NotEmpty();
        RuleFor(t => t.InitialCredit).GreaterThanOrEqualTo(0);
    }
}
