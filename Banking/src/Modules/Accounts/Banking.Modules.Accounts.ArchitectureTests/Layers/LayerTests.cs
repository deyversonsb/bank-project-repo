using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking.Modules.Accounts.ArchitectureTests.Abstractions;
using NetArchTest.Rules;

namespace Banking.Modules.Accounts.ArchitectureTests.Layers;
public class LayerTests : BaseTest
{
    [Fact]
    public void DomainLayer_ShouldNotHaveDependencyOn_ApplicationLayer()
    {
        Types.InAssembly(DomainAssembly)
             .Should()
             .NotHaveDependencyOn(ApplicationAssembly.GetName().Name)
             .GetResult()
             .ShoulBeSuccessful();
    }

    [Fact]
    public void DomainLayer_ShouldNotHaveDependencyOn_InfrastructureLayer()
    {
        Types.InAssembly(DomainAssembly)
             .Should()
             .NotHaveDependencyOn(InfrastructureAssembly.GetName().Name)
             .GetResult()
             .ShoulBeSuccessful();
    }

    [Fact]
    public void ApplicationLayer_ShouldNotHaveDependencyOn_InfrastructureLayer()
    {
        Types.InAssembly(ApplicationAssembly)
             .Should()
             .NotHaveDependencyOn(InfrastructureAssembly.GetName().Name)
             .GetResult()
             .ShoulBeSuccessful();
    }

    [Fact]
    public void ApplicationLayer_ShouldNotHaveDependencyOn_PresentationLayer()
    {
        Types.InAssembly(ApplicationAssembly)
             .Should()
             .NotHaveDependencyOn(PresentationAssembly.GetName().Name)
             .GetResult()
             .ShoulBeSuccessful();
    }

    [Fact]
    public void PresentationLayer_ShouldNotHaveDependencyOn_InfrastructureLayer()
    {
        Types.InAssembly(PresentationAssembly)
             .Should()
             .NotHaveDependencyOn(InfrastructureAssembly.GetName().Name)
             .GetResult()
             .ShoulBeSuccessful();
    }
}
