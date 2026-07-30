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
    /// Gets a valid dimension value from the user.
    /// </summary>
    /// <param name="message"> The message displayed when prompting for input. </param>
    /// <returns>
    /// The validated dimension value, or null if the operation is cancelled.
    /// </returns>
    public static double? GetDimension(string message)
    {
        double dimension;
        string? input;
        bool isValidDimension = true;
        do
        {
            Console.WriteLine(message);
            input = Console.ReadLine();
            if (Enum.TryParse(input, true, out MenuContent.Exit choice) && Enum.IsDefined(typeof(MenuContent.Exit), choice))
            {
                return null;
            }

            if (!double.TryParse(input, out dimension))
            {
                Console.WriteLine(MessageConstants.InvalidDoubleInput);
                continue;
            }

            isValidDimension = !Validation.IsValidDimension(dimension);

            if (isValidDimension)
            {
                Console.WriteLine(MessageConstants.NegativeValue);
            }
        }
        while (isValidDimension);
        return dimension;
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
        decimal amount;
        string? input;
        bool isValidAmount = true;
        do
        {
            Console.WriteLine(message);
            input = Console.ReadLine();

            if (Enum.TryParse(input, true, out MenuContent.Exit choice) && Enum.IsDefined(typeof(MenuContent.Exit), choice))
            {
                return null;
            }

            if (!decimal.TryParse(input, out amount))
            {
                Console.WriteLine(MessageConstants.InvalidDoubleInput);
                continue;
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
            Console.WriteLine(message);
            name = Console.ReadLine();

            if (Enum.TryParse(name, true, out MenuContent.Exit choice) && Enum.IsDefined(typeof(MenuContent.Exit), choice))
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
        decimal accountNumber;
        bool isValidAccountNumber = true;
        string? input;
        do
        {
            Console.WriteLine(message);
            input = Console.ReadLine();

            if (Enum.TryParse(input, true, out MenuContent.Exit choice) && Enum.IsDefined(typeof(MenuContent.Exit), choice))
            {
                return null;
            }

            if (!decimal.TryParse(input, out accountNumber))
            {
                Console.WriteLine(MessageConstants.InvalidDoubleInput);
                continue;
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
            Console.WriteLine(message);
            color = Console.ReadLine();

            if (Enum.TryParse(color, true, out MenuContent.Exit choice) && Enum.IsDefined(typeof(MenuContent.Exit), choice))
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
            Console.WriteLine(message);
            mpin = Console.ReadLine();

            if (Enum.TryParse(mpin, true, out MenuContent.Exit choice) && Enum.IsDefined(typeof(MenuContent.Exit), choice))
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
