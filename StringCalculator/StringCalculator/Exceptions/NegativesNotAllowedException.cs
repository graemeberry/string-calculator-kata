namespace StringCalculator.Exceptions;

public class NegativesNotAllowedException : Exception
{
    private const string BaseExceptionMessage = "Negatives not allowed: ";

    public NegativesNotAllowedException(IEnumerable<int> negativeNumbers) : base($"{BaseExceptionMessage}{string.Join(",", negativeNumbers)}")
    {
    }
}