using InventoryManager.Constants;
using InventoryManager.EnumConstants;

namespace InventoryManager.View;

/// <summary>
/// Contains all the methods related to console operations.
/// </summary>
public static class InventoryView
{
    /// <summary>
    /// Clear console.
    /// </summary>
    public static void ClearConsole()
    {
        Console.Clear();
    }

    /// <summary>
    /// Display the string passes as a parameter.
    /// </summary>
    /// <param name="message"> Message that need to be displayed. </param>
    public static void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }

    /// <summary>
    /// Get input from user which is not null or empty.
    /// </summary>
    /// <param name="prompt"> Represent message displayed to user to get input. </param>
    /// <returns> Null if user choose to exit process; otherwise user input. </returns>
    public static string? GetStringInput(string prompt)
    {
        string? userInput;
        do
        {
            Console.WriteLine($"{prompt} {MessageConstants.ExitProcess}");
            userInput = Console.ReadLine();
            if (string.IsNullOrEmpty(userInput))
            {
                continue;
            }

            if (Enum.TryParse(userInput, true, out MenuConstants.Exit choice) && Enum.IsDefined(typeof(MenuConstants.Exit), choice))
            {
                return null;
            }

            break;
        }
        while (true);

        return userInput;
    }

    /// <summary>
    /// Get input from user which is a number and not null or empty.
    /// </summary>
    /// <param name="prompt"> Message that need to be displayed. </param>
    /// <returns> Null if user choose to exit process; otherwise user input. </returns>
    public static decimal? GetDecimalInput(string prompt)
    {
        decimal decimalInput;
        do
        {
            Console.WriteLine($"{prompt} {MessageConstants.ExitProcess}");
            string? userInput = Console.ReadLine();
            if (string.IsNullOrEmpty(userInput))
            {
                continue;
            }

            if (Enum.TryParse(userInput, true, out MenuConstants.Exit choice) && Enum.IsDefined(typeof(MenuConstants.Exit), choice))
            {
                return null;
            }

            if (!decimal.TryParse(userInput, out decimalInput))
            {
                Console.WriteLine(MessageConstants.InvalidDigit);
                continue;
            }

            break;
        }
        while (true);
        return decimalInput;
    }

    /// <summary>
    /// Get input from user which is a number and not null or empty.
    /// </summary>
    /// <param name="prompt"> Message that need to be displayed. </param>
    /// <returns> Null if user choose to exit process; otherwise user input. </returns>
    public static int? GetIntegerInput(string prompt)
    {
        int integerInput;
        do
        {
            Console.WriteLine($"{prompt} {MessageConstants.ExitProcess}");
            string? userInput = Console.ReadLine();
            if (string.IsNullOrEmpty(userInput))
            {
                continue;
            }

            if (Enum.TryParse(userInput, true, out MenuConstants.Exit choice) && Enum.IsDefined(typeof(MenuConstants.Exit), choice))
            {
                return null;
            }

            if (!int.TryParse(userInput, out integerInput))
            {
                Console.WriteLine(MessageConstants.InvalidDigit);
                continue;
            }

            break;
        }
        while (true);
        return integerInput;
    }
}
