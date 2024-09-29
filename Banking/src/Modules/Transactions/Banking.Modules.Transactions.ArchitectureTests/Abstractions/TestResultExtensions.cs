using FluentAssertions;
using NetArchTest.Rules;

namespace Banking.Modules.Transactions.ArchitectureTests.Abstractions;

internal static class TestResultExtensions
{
    internal static void ShoulBeSuccessful(this TestResult testResult)
    {
        testResult.FailingTypes?.Should().BeEmpty();
    }
}
