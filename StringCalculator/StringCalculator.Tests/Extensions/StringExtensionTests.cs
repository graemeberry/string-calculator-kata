using StringCalculator.Extensions;
using Xunit;

namespace StringCalculator.Tests.Extensions;

public class StringExtensionTests
{
    [Fact]
    public void String_ContainsCustomDelimiter_ReturnTrue()
    {
        // Arrange
        const string Delimiter = "//";
        const string StringContainingDelimiter = $"{Delimiter}somethingElse";
        const bool Expected = true;

        // Act
        var actual = StringContainingDelimiter.ContainsCustomDelimiter();

        // Assert
        Assert.Equal(Expected, actual);
    }

    [Fact]
    public void String_ContainsCustomLengthDelimiterPrefix_ReturnTrue()
    {
        // Arrange
        const string Delimiter = "[";
        const string StringContainingDelimiter = $"{Delimiter}somethingElse";
        const bool Expected = true;

        // Act
        var actual = StringContainingDelimiter.ContainsCustomLengthDelimiterPrefix();

        // Assert
        Assert.Equal(Expected, actual);
    }

    [Fact]
    public void String_ContainsCustomLengthDelimiterSuffix_ReturnTrue()
    {
        // Arrange
        const string Delimiter = "[";
        const string StringContainingDelimiter = $"{Delimiter}somethingElse";
        const bool Expected = true;

        // Act
        var actual = StringContainingDelimiter.ContainsCustomLengthDelimiterSuffix();

        // Assert
        Assert.Equal(Expected, actual);
    }
}