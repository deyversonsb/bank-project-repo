using FluentAssertions;
using NetArchTest.Rules;

namespace Banking.Modules.Accounts.ArchitectureTests.Abstractions;

internal static class TestResultExtensions
{
    internal static void ShoulBeSuccessful(this TestResult testResult)
    {
        testResult.FailingTypes?.Should().BeEmpty();
    }
}
