using Banking.Common.Application.Messaging;
using Banking.Modules.Transactions.ArchitectureTests.Abstractions;
using FluentValidation;
using NetArchTest.Rules;

namespace Banking.Modules.Transactions.ArchitectureTests.Application;
public class ApplicationTests : BaseTest
{
    [Fact]
    public void Command_Should_BeSealed()
    {
        Types.InAssembly(ApplicationAssembly)
             .That()
             .ImplementInterface(typeof(ICommand))
             .Or()
             .ImplementInterface(typeof(ICommand<>))
             .Should()
             .BeSealed()
             .GetResult()
             .ShoulBeSuccessful();
    }

    [Fact]
    public void Command_ShouldHave_NameEndingWith_Command()
    {
        Types.InAssembly(ApplicationAssembly)
             .That()
             .ImplementInterface(typeof(ICommand))
             .Or()
             .ImplementInterface(typeof(ICommand<>))
             .Should()
             .HaveNameEndingWith("Command")
             .GetResult()
             .ShoulBeSuccessful();
    }

    [Fact]
    public void CommandHandler_Should_NotBePublic()
    {
        Types.InAssembly(ApplicationAssembly)
             .That()
             .ImplementInterface(typeof(ICommandHandler<>))
             .Or()
             .ImplementInterface(typeof(ICommandHandler<,>))
             .Should()
             .NotBePublic()
             .GetResult()
             .ShoulBeSuccessful();
    }

    [Fact]
    public void CommandHandler_Should_BeSealed()
    {
        Types.InAssembly(ApplicationAssembly)
             .That()
             .ImplementInterface(typeof(ICommandHandler<>))
             .Or()
             .ImplementInterface(typeof(ICommandHandler<,>))
             .Should()
             .BeSealed()
             .GetResult()
             .ShoulBeSuccessful();
    }

    [Fact]
    public void CommandHandler_ShouldHave_NameEndingWith_CommandHandler()
    {
        Types.InAssembly(ApplicationAssembly)
             .That()
             .ImplementInterface(typeof(ICommandHandler<>))
             .Or()
             .ImplementInterface(typeof(ICommandHandler<,>))
             .Should()
             .HaveNameEndingWith("CommandHandler")
             .GetResult()
             .ShoulBeSuccessful();
    }

    [Fact]
    public void Query_Should_BeSealed()
    {
        Types.InAssembly(ApplicationAssembly)
             .That()
             .ImplementInterface(typeof(IQuery<>))
             .Should()
             .BeSealed()
             .GetResult()
             .ShoulBeSuccessful();
    }

    [Fact]
    public void Query_ShouldHave_NameEndingWith_Query()
    {
        Types.InAssembly(ApplicationAssembly)
             .That()
             .ImplementInterface(typeof(IQuery<>))
             .Should()
             .HaveNameEndingWith("Query")
             .GetResult()
             .ShoulBeSuccessful();
    }

    [Fact]
    public void QueryHandler_Should_NotBePulbic()
    {
        Types.InAssembly(ApplicationAssembly)
             .That()
             .ImplementInterface(typeof(IQueryHandler<,>))
             .Should()
             .NotBePublic()
             .GetResult()
             .ShoulBeSuccessful();
    }

    [Fact]
    public void QueryHandler_ShouldHave_NameEndingWith_QueryHandler()
    {
        Types.InAssembly(ApplicationAssembly)
             .That()
             .ImplementInterface(typeof(IQueryHandler<,>))
             .Should()
             .HaveNameEndingWith("QueryHandler")
             .GetResult()
             .ShoulBeSuccessful();
    }

    [Fact]
    public void Validator_Should_BeNotPublic()
    {
        Types.InAssembly(ApplicationAssembly)
             .That()
             .Inherit(typeof(AbstractValidator<>))
             .Should()
             .NotBePublic()
             .GetResult()
             .ShoulBeSuccessful();
    }

    [Fact]
    public void Validator_Should_BeSealed()
    {
        Types.InAssembly(ApplicationAssembly)
             .That()
             .Inherit(typeof(AbstractValidator<>))
             .Should()
             .BeSealed()
             .GetResult()
             .ShoulBeSuccessful();
    }

    [Fact]
    public void Validator_ShouldHave_NameEndingWith_Validator()
    {
        Types.InAssembly(ApplicationAssembly)
             .That()
             .Inherit(typeof(AbstractValidator<>))
             .Should()
             .HaveNameEndingWith("Validator")
             .GetResult()
             .ShoulBeSuccessful();
    }

    [Fact]
    public void DomainEventHandler_Should_NotBePublic()
    {
        Types.InAssembly(ApplicationAssembly)
             .That()
             .ImplementInterface(typeof(IDomainEventHandler<>))
             .Should()
             .NotBePublic()
             .GetResult()
             .ShoulBeSuccessful();
    }

    [Fact]
    public void DomainEventHandler_Should_BeSealed()
    {
        Types.InAssembly(ApplicationAssembly)
             .That()
             .ImplementInterface(typeof(IDomainEventHandler<>))
             .Should()
             .BeSealed()
             .GetResult()
             .ShoulBeSuccessful();
    }

    [Fact]
    public void DomainEventHandler_ShouldHave_NameEndingWith_DomainEventHandler()
    {
        Types.InAssembly(ApplicationAssembly)
             .That()
             .ImplementInterface(typeof(IDomainEventHandler<>))
             .Should()
             .HaveNameEndingWith("DomainEventHandler")
             .GetResult()
             .ShoulBeSuccessful();
    }
}
