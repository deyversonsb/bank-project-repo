using Banking.Modules.Transactions.ArchitectureTests.Abstractions;
using MassTransit;
using NetArchTest.Rules;

namespace Banking.Modules.Transactions.ArchitectureTests.Presentation;
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
}
