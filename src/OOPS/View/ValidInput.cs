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
    public static double? GetValidDoubleInput(string message)
    {
        double result;
        bool isValidInput;

        do
        {
            Console.WriteLine(message);
            string? input = Console.ReadLine();

            var isParsed = Enum.TryParse(input, true, out MenuContent.Exit choice);
            if (isParsed && Enum.IsDefined(typeof(MenuContent.Exit), choice))
            {
                return null;
            }

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
    public static decimal? GetValidDecimalInput(string message)
    {
        decimal result;
        bool isValidInput;

        do
        {
            Console.WriteLine(message);

            string? input = Console.ReadLine();
            var isParsed = Enum.TryParse(input, true, out MenuContent.Exit choice);
            if (isParsed && Enum.IsDefined(typeof(MenuContent.Exit), choice))
            {
                return null;
            }

            isValidInput = decimal.TryParse(input, out result);

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
    public static string? GetValidStringInput(string message)
    {
        string? result;
        bool isValidInput = false;

        do
        {
            Console.WriteLine(message);
            result = Console.ReadLine();

            if (result is null || string.IsNullOrEmpty(result.Trim()))
            {
                Console.WriteLine(MessageConstants.InvalidStringInput);
                continue;
            }

            var isParsed = Enum.TryParse(result, true, out MenuContent.Exit choice);
            if (isParsed && Enum.IsDefined(typeof(MenuContent.Exit), choice))
            {
                return null;
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
    public static double? GetMeasurement(string message)
    {
        double? measurement;
        bool isValidMeasurement;
        do
        {
            measurement = GetValidDoubleInput(message);
            if (measurement is null)
            {
                return null;
            }

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
    public static decimal? GetAmount(string message)
    {
        decimal? amount;
        bool isValidAmount;
        do
        {
            amount = GetValidDecimalInput(message);

            if (amount is null)
            {
                return null;
            }

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
    public static string? GetName(string message)
    {
        string? name;
        bool isValidName;
        do
        {
            name = GetValidStringInput(message);

            if (name is null)
            {
                return null;
            }

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
    public static decimal? GetAccountNumber(string message)
    {
        decimal? accountNumber;
        bool isValidAccountNumber;
        do
        {
            accountNumber = GetValidDecimalInput(message);

            if (accountNumber is null)
            {
                return null;
            }

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
    public static string? GetColor(string message)
    {
        string? color;
        bool isValidColor;
        do
        {
            color = GetValidStringInput(message);

            if (color is null)
            {
                return null;
            }

            isValidColor = !Validation.IsValidColor(color);

            if (isValidColor)
            {
                Console.WriteLine(MessageConstants.InvalidColor);
            }
        }
        while (isValidColor);
        return color;
    }

    /// <summary>
    /// Gets any key and clear the console.
    /// </summary>
    public static void GetAnyKey()
    {
        Console.WriteLine(MessageConstants.GetAnyKey);
        Console.ReadKey();
        Console.Clear();
    }

    /// <summary>
    /// Get vaild mpin from the user.
    /// </summary>
    /// <param name="message"> Message to display when getting input. </param>
    /// <returns> Mpin. </returns>
    public static string? GetMpin(string message)
    {
        string? mpin;
        bool isValidMpin;
        do
        {
            mpin = GetValidStringInput(message);

            if (mpin is null)
            {
                return null;
            }

            isValidMpin = !Validation.IsValidMpin(mpin);

            if (isValidMpin)
            {
                Console.WriteLine(MessageConstants.InvalidMpin);
            }
        }
        while (isValidMpin);
        return mpin;
    }
}
