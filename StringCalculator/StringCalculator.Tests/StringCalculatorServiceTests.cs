using System;
using StringCalculator.Exceptions;
using Xunit;

namespace StringCalculator.Tests;

public class StringCalculatorServiceTests
{
    [Fact]
    public void Add_GivenEmptyString_ReturnZero()
    {
        // Arrange
        const int Expected = 0;

        // Act
        var actual = StringCalculatorService.Add("");

        // Assert
        Assert.Equal(Expected, actual);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    public void Add_GivenSingleNumberString_ReturnTheNumber(string input, int expected)
    {
        // Arrange
        // Act
        var actual = StringCalculatorService.Add(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("2,3,4", 9)]
    [InlineData("2,3,4,5", 14)]
    public void Add_GivenNumbersSeparatedByCommaString_ReturnSumOfTheNumbers(string input, int expected)
    {
        // Arrange
        // Act
        var actual = StringCalculatorService.Add(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("1\n2", 3)]
    [InlineData("2\n3\n4", 9)]
    [InlineData("2\n3\n4\n5", 14)]
    public void Add_GivenNumbersSeparatedByNewLineString_ReturnSumOfTheNumbers(string input, int expected)
    {
        // Arrange
        // Act
        var actual = StringCalculatorService.Add(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("//;\n1;2", 3)]
    [InlineData("//#\n2#3#4", 9)]
    [InlineData("//\n\n2\n3\n4\n5", 14)]
    public void Add_GivenNumbersSeparatedByCustomDelimiterString_ReturnSumOfTheNumbers(string input, int expected)
    {
        // Arrange
        // Act
        var actual = StringCalculatorService.Add(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("1\n-2", "Negatives not allowed: -2")]
    [InlineData("2,-3,4", "Negatives not allowed: -3")]
    [InlineData("//#\n2#3#-4#-5", "Negatives not allowed: -4,-5")]
    public void Add_GivenNumberStringContainsNegativeNumbers_ThrowNegativesNotAllowedException(string input, string expectedExceptionMessage)
    {
        // Arrange
        // Act
        void Act() => StringCalculatorService.Add(input);

        // Assert
        var exception = Assert.Throws<NegativesNotAllowedException>((Action)Act);
        Assert.Equal(expectedExceptionMessage, exception.Message);
    }

    [Theory]
    [InlineData("1\n2\n1001", 3)]
    [InlineData("2,3,4,1000", 1009)]
    [InlineData("//#\n2#3#4#5#1002", 14)]
    public void Add_GivenNumberStringContainsNumbersGreaterThan1000_DoNotIncludeNumbersGreaterThan1000InSum(string input, int expected)
    {
        // Arrange
        // Act
        var actual = StringCalculatorService.Add(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("//[|||]\n1|||2", 3)]
    [InlineData("//[||||]\n2||||3||||4", 9)]
    [InlineData("//[|||||]\n2|||||3|||||4|||||5", 14)]
    public void Add_GivenNumbersSeparatedByDelimiterInSquareBracketsOfAnyLengthString_ReturnSumOfTheNumbers(string input, int expected)
    {
        // Arrange
        // Act
        var actual = StringCalculatorService.Add(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("//[|][#]\n1|2#3", 6)]
    [InlineData("//[|][#][,]\n1|2#3,4", 10)]
    [InlineData("//[|][#][,][\n]\n1|2#3,4\n5", 15)]
    public void Add_GivenNumbersSeparatedByMultipleDelimitersInSquareBracketsString_ReturnSumOfTheNumbers(string input, int expected)
    {
        // Arrange
        // Act
        var actual = StringCalculatorService.Add(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("//[||][#]\n1||2#3", 6)]
    [InlineData("//[|][###][,]\n1|2###3,4", 10)]
    [InlineData("//[|||][#][,,][\n]\n1|||2#3,,4\n5", 15)]
    public void Add_GivenNumbersSeparatedByMultipleDelimitersInSquareBracketsOfAnyLengthString_ReturnSumOfTheNumbers(string input, int expected)
    {
        // Arrange
        // Act
        var actual = StringCalculatorService.Add(input);

        // Assert
        Assert.Equal(expected, actual);
    }
}