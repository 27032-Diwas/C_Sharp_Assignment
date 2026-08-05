using InventoryManager.Constants;

namespace InventoryManager.View;

/// <summary>
/// Display messages to user and get input from user.
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
    /// Display the string passed as a parameter.
    /// </summary>
    /// <param name="message"> Message that needs to be displayed. </param>
    public static void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }

    /// <summary>
    /// Gets input from user which is not null or empty.
    /// </summary>
    /// <param name="prompt"> Represents message displayed to user to get input. </param>
    /// <returns> Null if user chooses to exit process; otherwise user input. </returns>
    public static string? GetStringInput(string prompt)
    {
        string? userInput;
        do
        {
            Console.WriteLine($"{prompt} {MessageConstants.ExitProcess}");
            userInput = Console.ReadLine();
            if (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine(MessageConstants.InvalidString);
                continue;
            }

            if (userInput.ToUpper().Equals(MessageConstants.Exit))
            {
                return null;
            }

            break;
        }
        while (true);

        return userInput;
    }

    /// <summary>
    /// Gets input from user which is a number and not null or empty.
    /// </summary>
    /// <param name="prompt"> Message that needs to be displayed. </param>
    /// <returns> Null if user chooses to exit process; otherwise user input. </returns>
    public static decimal? GetDecimalInput(string prompt)
    {
        decimal decimalInput;
        do
        {
            Console.WriteLine($"{prompt} {MessageConstants.ExitProcess}");
            string? userInput = Console.ReadLine();
            if (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine(MessageConstants.InvalidDigit);
                continue;
            }

            if (userInput.ToUpper().Equals(MessageConstants.Exit))
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
    /// Gest input from user which is a number and not null or empty.
    /// </summary>
    /// <param name="prompt"> Message that needs to be displayed. </param>
    /// <returns> Null if user chooses to exit process; otherwise user input. </returns>
    public static int? GetIntegerInput(string prompt)
    {
        int integerInput;
        do
        {
            Console.WriteLine($"{prompt} {MessageConstants.ExitProcess}");
            string? userInput = Console.ReadLine();
            if (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine(MessageConstants.InvalidDigit);
                continue;
            }

            if (userInput.ToUpper().Equals(MessageConstants.Exit))
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
