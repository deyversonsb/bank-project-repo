using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Banking.Modules.Accounts.Domain.Customers;
using Banking.Modules.Accounts.Infrastructure;
using Banking.Modules.Transactions.Domain.Transactions;
using Banking.Modules.Transactions.Infrastructure;
using BankingArchitectureTests.Abstractions;
using NetArchTest.Rules;

namespace BankingArchitectureTests.Layers;
public class ModuleTests : BaseTest
{
    [Fact]
    public void AccountsModule_ShouldNotHaveDependecyOn_AnyOtherModule()
    {
        string[] otherModules = [TransactionsNamespace];

        List<Assembly> accountsAssemblies =
        [
            typeof(Customer).Assembly,
            Banking.Modules.Accounts.Application.AssemblyReference.Assembly,
            Banking.Modules.Accounts.Presentation.AssemblyReference.Assembly,
            typeof(AccountsModule).Assembly
        ];

        Types.InAssemblies(accountsAssemblies)
             .Should()
             .NotHaveDependencyOnAny(otherModules)
             .GetResult()
             .ShoulBeSuccessful();
    }

    [Fact]
    public void TransactionsModule_ShouldNotHaveDependecyOn_AnyOtherModule()
    {
        string[] otherModules = [AccountsNamespace];
        string[] integrationsEventsModules = [AccountsIntegrationEventsNamespace];

        List<Assembly> transactionsAssemblies =
        [
            typeof(Transaction).Assembly,
            Banking.Modules.Transactions.Application.AssemblyReference.Assembly,
            Banking.Modules.Transactions.Presentation.AssemblyReference.Assembly,
            typeof(TransactionsModule).Assembly
        ];

        Types.InAssemblies(transactionsAssemblies)
             .That()
             .DoNotHaveDependencyOnAny(integrationsEventsModules)
             .Should()
             .NotHaveDependencyOnAny(otherModules)
             .GetResult()
             .ShoulBeSuccessful();
    }
}
