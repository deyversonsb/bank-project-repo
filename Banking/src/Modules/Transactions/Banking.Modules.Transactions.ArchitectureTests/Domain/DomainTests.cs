﻿using System.Reflection;
using Banking.Common.Domain;
using Banking.Modules.Transactions.ArchitectureTests.Abstractions;
using FluentAssertions;
using NetArchTest.Rules;

namespace Banking.Modules.Transactions.ArchitectureTests.Domain;
public class DomainTests : BaseTest
{
    [Fact]
    public void DomainEvents_Should_BeSealed()
    {
        Types.InAssembly(DomainAssembly)
             .That()
             .ImplementInterface(typeof(IDomainEvent))
             .Or()
             .Inherit(typeof(DomainEvent))
             .Should()
             .BeSealed()
             .GetResult()
             .ShoulBeSuccessful();
    }

    [Fact]
    public void DomainEvent_ShouldHave_DomainEventPostfix()
    {
        Types.InAssembly(DomainAssembly)
             .That()
             .ImplementInterface(typeof(IDomainEvent))
             .Or()
             .Inherit(typeof(DomainEvent))
             .Should()
             .HaveNameEndingWith("DomainEvent")
             .GetResult()
             .ShoulBeSuccessful();
    }

    [Fact]    
    public void Entities_ShouldHave_PrivateParameterlessConstructor()
    {
        IEnumerable<Type> entityTypes = Types.InAssembly(DomainAssembly)
            .That()
            .Inherit(typeof(Entity))
            .GetTypes();

        var failingTypes = new List<Type>();
        foreach (Type entityType in entityTypes)
        {
            ConstructorInfo[] constructors = entityType.GetConstructors(BindingFlags.NonPublic |
                                                                        BindingFlags.Instance);

            if (!constructors.Any(c => c.IsPrivate && c.GetParameters().Length == 0))
            {
                failingTypes.Add(entityType);
            }
        }

        failingTypes.Should().BeEmpty();
    }

    [Fact]
    public void Entities_ShouldOnlyHave_PrivateConstructors()
    {
        IEnumerable<Type> entityTypes = Types.InAssembly(DomainAssembly)
            .That()
            .Inherit(typeof(Entity))
            .GetTypes();

        var failingTypes = new List<Type>();
        foreach (Type entityType in entityTypes)
        {
            ConstructorInfo[] constructors = entityType.GetConstructors(BindingFlags.Public |
                                                                        BindingFlags.Instance);

            if (constructors.Any())
            {
                failingTypes.Add(entityType);
            }
        }

        failingTypes.Should().BeEmpty();
    }
}
