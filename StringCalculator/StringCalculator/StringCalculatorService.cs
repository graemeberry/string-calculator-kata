using StringCalculator.Exceptions;
using StringCalculator.Extensions;

namespace StringCalculator;

public class StringCalculatorService
{
    public static int Add(string input)
    {
        var numbersToSum = SplitNumbersFromInput(input);

        ThrowExceptionIfNegativeNumbersAreFound(numbersToSum);

        return numbersToSum.Where(number => number.IsLessThanOrEqualTo1000()).Sum();
    }

    private static List<int> SplitNumbersFromInput(string input)
    {
        var delimitersToSplitOn = GetDelimiters(input);
        var splitNumbers = input.Split(delimitersToSplitOn, StringSplitOptions.RemoveEmptyEntries);

        var numbers = new List<int>();
        foreach (var splitNumber in splitNumbers)
        {
            if (int.TryParse(splitNumber, out var number))
            {
                numbers.Add(number);
            }
        }

        return numbers;
    }

    private static string[] GetDelimiters(string input)
    {
        var delimiters = new List<string> { ",", "\n" };

        var customDelimiters = GetCustomDelimiters(input);
        delimiters.AddRange(customDelimiters);

        return delimiters.ToArray();
    }
    
    private static IEnumerable<string> GetCustomDelimiters(string input)
    {
        var delimiters = new List<string>();
        if (!input.ContainsCustomDelimiter()) return delimiters;

        const string CustomDelimiterPrefix = "//";
        const string CustomDelimiterNewLinePrefix = "\n";

        var customDelimiters = input.Split(CustomDelimiterNewLinePrefix).First().Replace(CustomDelimiterPrefix, "");
        if (ContainsCustomLengthDelimiters(customDelimiters))
        {
            delimiters.AddRange(GetCustomLengthDelimiters(customDelimiters));
        }
        else
        {
            delimiters.Add(customDelimiters);
        }
        return delimiters;
    }

    private static bool ContainsCustomLengthDelimiters(string input)
    {
        return input.ContainsCustomLengthDelimiterPrefix() && input.ContainsCustomLengthDelimiterSuffix();
    }

    private static IEnumerable<string> GetCustomLengthDelimiters(string input)
    {
        const char CustomLengthDelimiterPrefix = '[';
        const char CustomLengthDelimiterSuffix = ']';

        return input.Split(CustomLengthDelimiterPrefix, CustomLengthDelimiterSuffix);
    }

    private static void ThrowExceptionIfNegativeNumbersAreFound(IEnumerable<int> numbers)
    {
        var negativeNumbers = numbers.Where(number => number < 0).ToList();
        if (negativeNumbers.Any())
        {
            throw new NegativesNotAllowedException(negativeNumbers);
        }
    }
}