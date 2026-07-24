using OOPS.Constants;

namespace OOPS.View;

/// <summary>
/// Contains method to get input.
/// </summary>
public static class ValidInput
{
    /// <summary>
    /// Checks for valid double input.
    /// </summary>
    /// <param name="message"> Failure Message. </param>
    /// <returns> Double value. </returns>
    public static double GetValidDoubleInput(string message)
    {
        double result;
        bool isValidInput;

        do
        {
            Console.WriteLine(message);
            isValidInput = double.TryParse(Console.ReadLine(), out result);

            if (!isValidInput)
            {
                Console.WriteLine(MessageConstants.InvalidDoubleInput);
            }
        }
        while (!isValidInput);

        return result;
    }

    /// <summary>
    /// Checks for valid double input.
    /// </summary>
    /// <param name="message"> Failure Message. </param>
    /// <returns> Double value. </returns>
    public static decimal GetValidDecimalInput(string message)
    {
        decimal result;
        bool isValidInput;

        do
        {
            Console.WriteLine(message);
            isValidInput = decimal.TryParse(Console.ReadLine(), out result);

            if (!isValidInput)
            {
                Console.WriteLine(MessageConstants.InvalidDoubleInput);
            }
        }
        while (!isValidInput);

        return result;
    }

    /// <summary>
    /// Check for valid string input.
    /// </summary>
    /// <param name="message"> Failure message. </param>
    /// <returns> string value. </returns>
    public static string GetValidStringInput(string message)
    {
        string? result;
        bool isValidInput = false;

        do
        {
            Console.WriteLine(message);
            result = Console.ReadLine();

            if (result is null || result.Trim() == string.Empty)
            {
                Console.WriteLine(MessageConstants.InvalidStringInput);
                continue;
            }
            isValidInput = true;
        }
        while (!isValidInput);

        return result;
    }
}
