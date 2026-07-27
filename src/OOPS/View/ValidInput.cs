using OOPS.Constants;
using OOPS.Helper;

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

    /// <summary>
    /// Get vaild salary from the user.
    /// </summary>
    /// <returns> Return salary. </returns>
    public static decimal GetAmount()
    {
        decimal amount;
        bool isValidAmount;
        do
        {
            amount = GetValidDecimalInput(MessageConstants.GetEmployeeSalary);
            isValidAmount = !Validation.IsAmountValid(amount);

            if (isValidAmount)
            {
                Console.WriteLine(MessageConstants.NegativeValue);
            }
        }
        while (isValidAmount);
        return amount;
    }

    /// <summary>
    /// Get vaild name from the user.
    /// </summary>
    /// <returns> Name. </returns>
    public static string GetName()
    {
        string? name;
        bool isValidName;
        do
        {
            name = GetValidStringInput(MessageConstants.GetEmployeeName);
            isValidName = !Validation.IsValidName(name);

            if (isValidName)
            {
                Console.WriteLine(MessageConstants.NegativeValue);
            }
        }
        while (isValidName);
        return name;
    }
}
