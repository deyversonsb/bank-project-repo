using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking.Modules.Accounts.ArchitectureTests.Abstractions;
using MassTransit;
using NetArchTest.Rules;

namespace Banking.Modules.Accounts.ArchitectureTests.Presentation;
public class PresentationTests : BaseTest
{
    [Fact]
    public void IntegrationEventHandler_Should_BeSealed()
    {
        Types.InAssembly(PresentationAssembly)
             .That()
             .ImplementInterface(typeof(IConsumer<>))
             .Should()
             .BeSealed()
             .GetResult()
             .ShoulBeSuccessful();
    }

    [Fact]
    public void IntegrationEventHandler_ShouldHave_NameEndingWith_DomainEventHandler()
    {
        Types.InAssembly(PresentationAssembly)
             .That()
             .ImplementInterface(typeof(IConsumer<>))
             .Should()
             .HaveNameEndingWith("Consumer")
             .GetResult()
             .ShoulBeSuccessful();
    }
}
