using System.Reflection;
using Banking.Modules.Transactions.Domain.Transactions;
using Banking.Modules.Transactions.Infrastructure;

namespace Banking.Modules.Transactions.ArchitectureTests.Abstractions;
public abstract class BaseTest
{
    protected static readonly Assembly ApplicationAssembly = typeof(Transactions.Application.AssemblyReference).Assembly;

    protected static readonly Assembly DomainAssembly = typeof(Transaction).Assembly;

    protected static readonly Assembly InfrastructureAssembly = typeof(TransactionsModule).Assembly;

    protected static readonly Assembly PresentationAssembly = typeof(Transactions.Presentation.AssemblyReference).Assembly;
}
