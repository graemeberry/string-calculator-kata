using StringCalculator.Extensions;
using Xunit;

namespace StringCalculator.Tests.Extensions;

public class NumberExtensionTests
{
    [Theory]
    [InlineData(1000, true)]
    [InlineData(1001, false)]
    public void Number_IsLessThanOrEqualTo1000(int number, bool expected)
    {
        // Act
        var actual = number.IsLessThanOrEqualTo1000();

        // Assert
        Assert.Equal(expected, actual);
    }
}