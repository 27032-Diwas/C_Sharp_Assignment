using OOPS.Constants;
using OOPS.EnumConstants;
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
            string? input = Console.ReadLine();

            // var isParsed = Enum.TryParse(input, true, out MenuContent.Exit choice);
            // if (isParsed && Enum.IsDefined(typeof(MenuContent.Exit), choice))
            // {
            //    return ;
            // }
            isValidInput = double.TryParse(input, out result);

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
        string result;
        bool isValidInput = false;

        do
        {
            Console.WriteLine(message);
            result = Console.ReadLine();

            if (string.IsNullOrEmpty(result.Trim()))
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
    /// Get vaild measurement from the user.
    /// </summary>
    /// /// <param name="message"> Message to display when getting input. </param>
    /// <returns> Return salary. </returns>
    public static double GetMeasurement(string message)
    {
        double measurement;
        bool isValidMeasurement;
        do
        {
            measurement = GetValidDoubleInput(message);
            isValidMeasurement = !Validation.IsValidMeasurement(measurement);

            if (isValidMeasurement)
            {
                Console.WriteLine(MessageConstants.NegativeValue);
            }
        }
        while (isValidMeasurement);
        return measurement;
    }

    /// <summary>
    /// Get vaild salary from the user.
    /// </summary>
    /// /// <param name="message"> Message to display when getting input. </param>
    /// <returns> Return salary. </returns>
    public static decimal GetAmount(string message)
    {
        decimal amount;
        bool isValidAmount;
        do
        {
            amount = GetValidDecimalInput(message);
            isValidAmount = !Validation.IsValidAmount(amount);

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
    /// <param name="message"> Message to display when getting input. </param>
    /// <returns> Name. </returns>
    public static string GetName(string message)
    {
        string? name;
        bool isValidName;
        do
        {
            name = GetValidStringInput(message);
            isValidName = !Validation.IsValidName(name);

            if (isValidName)
            {
                Console.WriteLine(MessageConstants.NameTooShort);
            }
        }
        while (isValidName);
        return name;
    }

    /// <summary>
    /// Get vaild account number from the user.
    /// </summary>
    /// <param name="message"> Message to display when getting input. </param>
    /// <returns> Account number. </returns>
    public static decimal GetAccountNumber(string message)
    {
        decimal accountNumber;
        bool isValidAccountNumber;
        do
        {
            accountNumber = GetValidDecimalInput(message);
            isValidAccountNumber = !Validation.IsValidAccountNumber(accountNumber);

            if (isValidAccountNumber)
            {
                Console.WriteLine(MessageConstants.InvalidAccountNumber);
            }
        }
        while (isValidAccountNumber);
        return accountNumber;
    }

    /// <summary>
    /// Get vaild color from the user.
    /// </summary>
    /// <param name="message"> Message to display when getting input. </param>
    /// <returns> Color. </returns>
    public static string GetColor(string message)
    {
        string? color;
        bool isValidColor;
        do
        {
            color = GetValidStringInput(message);
            isValidColor = !Validation.IsValidColor(color);

            if (isValidColor)
            {
                Console.WriteLine(MessageConstants.InvalidColor);
            }
        }
        while (isValidColor);
        return color;
    }
}
