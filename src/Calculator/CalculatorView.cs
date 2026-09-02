using System.Text.RegularExpressions;
using Calculator.Constants;

namespace Calculator;

/// <summary>
/// Contains all console operations.
/// </summary>
public class CalculatorView
{
    /// <summary>
    /// Gets input from the user.
    /// </summary>
    /// <param name="prompt"> Prompt displayed to user to get input. </param>
    /// <returns> Input as a integer. </returns>
    /// <exception cref="OperationCanceledException"> Exception throwed when user enters cancel the operation. </exception>
    public int GetInteger(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine(ErrorMessages.InvalidString);
                continue;
            }

            if (input.Equals(UserPrompts.Exit, StringComparison.OrdinalIgnoreCase))
            {
                throw new OperationCanceledException();
            }

            if (!int.TryParse(input, out int value))
            {
                Console.WriteLine(ErrorMessages.InvalidNumber);
                continue;
            }

            return value;
        }
    }

    /// <summary>
    /// Clears console.
    /// </summary>
    public void ClearConsole()
    {
        Console.Clear();
        Console.WriteLine("\x1b[3J");
    }

    /// <summary>
    /// Display the string passed as a parameter in red color.
    /// </summary>
    /// <param name="errorMessage"> Error message that need to be displayed. </param>
    public void DisplayErrorMessage(string errorMessage)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(errorMessage);
        Console.ResetColor();
        Console.WriteLine();
    }

    /// <summary>
    /// Displays the string passed as a parameter in green color.
    /// </summary>
    /// <param name="successMessage"> Success that need to be displayed. </param>
    public void DisplaySuccessMessage(string successMessage)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(successMessage);
        Console.ResetColor();
        Console.WriteLine();
    }

    /// <summary>
    /// Display the string passed as a parameter.
    /// </summary>
    /// <param name="message"> Message that need to be displayed. </param>
    public void DisplayMessage(string message) => Console.WriteLine(message);

    /// <summary>
    /// Gets a valid menu option selected by the user.
    /// </summary>
    /// <typeparam name="T"> The enumeration type. </typeparam>
    /// <param name="message"> The message displayed before the menu options. </param>
    /// <param name="prompt"> The message displayed to get option from user. </param>
    /// <returns>
    /// The selected enumeration value.
    /// </returns>
    public T GetMenuChoice<T>(string message, string prompt)
        where T : struct, Enum
    {
        while (true)
        {
            Console.WriteLine($"{message}\n");
            DisplayOptions<T>();
            Console.WriteLine(prompt);
            string input = string.Concat(Console.ReadLine()?.Where(c => !char.IsWhiteSpace(c)) ?? string.Empty);
            if (input.Equals(UserPrompts.Exit, StringComparison.OrdinalIgnoreCase))
            {
                throw new OperationCanceledException();
            }

            if (Enum.TryParse(input, true, out T choice) &&
                Enum.IsDefined(typeof(T), choice))
            {
                return choice;
            }

            Console.Clear();
            Console.WriteLine("\x1b[3J");
            this.DisplayErrorMessage($"{ErrorMessages.InvalidOption}");
        }
    }

    /// <summary>
    /// Waits for the user to press a key and then clears the console.
    /// </summary>
    public void GetAnyKey()
    {
        Console.WriteLine($"\n{UserPrompts.GetAnyKey}");
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("\x1b[3J");
    }

    /// <summary>
    /// Displays all values defined in the specific enum values.
    /// </summary>
    /// <typeparam name="T"> Type : enum </typeparam>
    /// <param name="excluded"> Name of Enum </param>
    private static void DisplayOptions<T>()
        where T : Enum
    {
        foreach (T optionCategory in Enum.GetValues(typeof(T)))
        {
            string? displayName = Regex.Replace(optionCategory.ToString(), @"(?<!^)([A-Z])", " $1");
            Console.WriteLine($"[{Convert.ToInt32(optionCategory)}] {displayName}");
        }
    }
}
