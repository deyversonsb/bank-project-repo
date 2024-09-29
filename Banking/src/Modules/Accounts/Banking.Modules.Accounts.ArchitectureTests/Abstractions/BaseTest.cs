using System.Reflection;
using Banking.Modules.Accounts.Domain.Customers;
using Banking.Modules.Accounts.Infrastructure;

namespace Banking.Modules.Accounts.ArchitectureTests.Abstractions;
public abstract class BaseTest
{
    protected static readonly Assembly ApplicationAssembly = typeof(Accounts.Application.AssemblyReference).Assembly;

    protected static readonly Assembly DomainAssembly = typeof(Customer).Assembly;

    protected static readonly Assembly InfrastructureAssembly = typeof(AccountsModule).Assembly;

    protected static readonly Assembly PresentationAssembly = typeof(Accounts.Presentation.AssemblyReference).Assembly;
}
