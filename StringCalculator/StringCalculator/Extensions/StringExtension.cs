namespace StringCalculator.Extensions;

public static class StringExtension
{
    public static bool ContainsCustomDelimiter(this string input)
    {
        const string CustomDelimiter = "//";
        return input.Contains(CustomDelimiter);
    }

    public static bool ContainsCustomLengthDelimiterPrefix(this string input)
    {
        const string CustomLengthDelimiterPrefix = "[";
        return input.Contains(CustomLengthDelimiterPrefix);
    }

    public static bool ContainsCustomLengthDelimiterSuffix(this string input)
    {
        const string CustomLengthDelimiterSuffix = "[";
        return input.Contains(CustomLengthDelimiterSuffix);
    }
}