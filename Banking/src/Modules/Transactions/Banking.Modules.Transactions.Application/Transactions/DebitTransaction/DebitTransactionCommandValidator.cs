using FluentValidation;

namespace Banking.Modules.Transactions.Application.Transactions.DebitTransaction;
internal sealed class DebitTransactionCommandValidator : AbstractValidator<DebitTransactionCommand>
{
    public DebitTransactionCommandValidator()
    {
        RuleFor(t => t.CustomerId).NotEmpty();
        RuleFor(t => t.DebitValue).GreaterThan(0);
    }
}
