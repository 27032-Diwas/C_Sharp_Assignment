using OOPS.Constants;
using OOPS.EnumConstants;
using OOPS.Helper;

namespace OOPS.View;

/// <summary>
/// Provides methods for validating and retrieving user input.
/// </summary>
public static class ValidInput
{
    /// <summary>
    /// Gets a valid double value from the user.
    /// </summary>
    /// <param name="message"> The message displayed when prompting for input. </param>
    /// <returns>
    /// The validated double value, or null if the operation is cancelled.
    /// </returns>
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
    /// Gets a valid decimal value from the user.
    /// </summary>
    /// <param name="message"> The message displayed when prompting for input. </param>
    /// <returns>
    /// The validated decimal value, or null if the operation is cancelled.
    /// </returns>
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
    /// Gets a valid non-empty string value from the user.
    /// </summary>
    /// <param name="message"> The message displayed when prompting for input. </param>
    /// <returns>
    /// The validated string value, or null if the operation is cancelled.
    /// </returns>
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
    /// Gets a valid measurement value from the user.
    /// </summary>
    /// <param name="message"> The message displayed when prompting for input. </param>
    /// <returns>
    /// The validated measurement value, or null if the operation is cancelled.
    /// </returns>
    public static double? GetMeasurement(string message)
    {
        double? dimensions;
        bool isValidDimensions;
        do
        {
            dimensions = GetValidDoubleInput(message);
            if (dimensions is null)
            {
                return null;
            }

            isValidDimensions = !Validation.IsValidDimensions(dimensions);

            if (isValidDimensions)
            {
                Console.WriteLine(MessageConstants.NegativeValue);
            }
        }
        while (isValidDimensions);
        return dimensions;
    }

    /// <summary>
    /// Gets a valid amount from the user.
    /// </summary>
    /// <param name="message"> The message displayed when prompting for input. </param>
    /// <returns>
    /// The validated amount, or null if the operation is cancelled.
    /// </returns>
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
    /// Gets a valid name from the user.
    /// </summary>
    /// <param name="message"> The message displayed when prompting for input. </param>
    /// <returns>
    /// The validated name, or null if the operation is cancelled.
    /// </returns>
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
    /// Gets a valid account number from the user.
    /// </summary>
    /// <param name="message"> The message displayed when prompting for input. </param>
    /// <returns>
    /// The validated account number, or null if the operation is cancelled.
    /// </returns>
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
    /// Gets a valid color from the user.
    /// </summary>
    /// <param name="message"> The message displayed when prompting for input. </param>
    /// <returns>
    /// The validated color, or null if the operation is cancelled.
    /// </returns>
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
    /// Waits for the user to press a key and then clears the console.
    /// </summary>
    public static void GetAnyKey()
    {
        Console.WriteLine(MessageConstants.GetAnyKey);
        Console.ReadKey();
        Console.Clear();
    }

    /// <summary>
    /// Gets a valid MPIN from the user.
    /// </summary>
    /// <param name="message">The message displayed when prompting for input.</param>
    /// <returns>
    /// The validated MPIN, or null if the operation is cancelled.
    /// </returns>
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
