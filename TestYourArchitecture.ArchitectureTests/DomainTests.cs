using System.Reflection;
using NetArchTest.Rules;
using Xunit;

namespace TestYourArchitecture.ArchitectureTests;

public class DomainTests
{
    [Fact]
    public void ShouldPass_WhenDomainDoesNotReferenceApplication()
    {
        // Arrange
        var types = Types.InAssembly(Assembly.Load("TestYourArchitecture.Domain"));
        
        // Act
        var result = types
            .ShouldNot()
            .HaveDependencyOn("TestYourArchitecture.Application")
            .GetResult();
        
        // Assert
        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void ShouldPass_WhenAllPublicClassesAreSealed()
    {
        // Arrange
        var types = Types.InAssembly(Assembly.Load("TestYourArchitecture.Domain"));
        
        // Act
        var result = types
            .That()
            .ArePublic()
            .Should()
            .BeSealed()
            .GetResult();
        
        // Assert
        Assert.True(result.IsSuccessful);
    }
}