using System.Text.RegularExpressions;
using ExceptionHandling.Constants;

namespace ExceptionHandling.View;

/// <summary>
/// Displays message to user and gets user input.
/// </summary>
public class ConsoleUI
{
    /// <summary>
    /// Display the string passed as a parameter.
    /// </summary>
    /// <param name="message"> Message that need to be displayed. </param>
    public void DisplayMessage(string message) => Console.WriteLine(message);

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
    /// Clears console.
    /// </summary>
    public void ClearConsole()
    {
        Console.Clear();
        Console.WriteLine("\x1b[3J");
    }

    /// <summary>
    /// Gets input from user which is not null or empty.
    /// </summary>
    /// <param name="prompt"> Represents message displayed to user to get input. </param>
    /// <returns> Null if user chooses to exit process; otherwise user input. </returns>
    public string GetStringInput(string prompt)
    {
        string? userInput;
        while (true)
        {
            Console.WriteLine($"{prompt} {UserPrompts.ExitProcess}");
            userInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                this.DisplayErrorMessage(ErrorMessages.InvalidString);
                continue;
            }

            if (userInput.Equals(HeaderMessages.Exit, StringComparison.OrdinalIgnoreCase))
            {
                throw new OperationCanceledException();
            }

            return userInput.Trim();
        }
    }

    /// <summary>
    /// Gets input from user which is a valid number.
    /// </summary>
    /// <param name="prompt"> Message that needs to be displayed. </param>
    /// <returns> Null if user chooses to exit process; otherwise user input. </returns>
    public int GetIntegerInput(string prompt)
    {
        while (true)
        {
            Console.WriteLine($"{prompt} {UserPrompts.ExitProcess}");
            string? userInput = Console.ReadLine();
            if (string.IsNullOrEmpty(userInput))
            {
                this.DisplayErrorMessage(ErrorMessages.InvalidNumber);
                continue;
            }

            if (userInput.Equals(HeaderMessages.Exit, StringComparison.OrdinalIgnoreCase))
            {
                throw new OperationCanceledException();
            }

            if (!int.TryParse(userInput, out int integerInput))
            {
                this.DisplayErrorMessage(ErrorMessages.InvalidNumber);
                continue;
            }

            return integerInput;
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
            if (input.Equals(HeaderMessages.Exit, StringComparison.OrdinalIgnoreCase))
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
    /// Displays all values defined in the specific enum values.
    /// </summary>
    /// <typeparam name="T"> Type : enum </typeparam>
    /// <param name="excluded"> Name of Enum </param>
    private static void DisplayOptions<T>(params T[] excluded)
        where T : Enum
    {
        foreach (T optionCategory in Enum.GetValues(typeof(T)))
        {
            if (excluded.Contains(optionCategory))
            {
                continue;
            }

            string? displayName = Regex.Replace(optionCategory.ToString(), @"(?<!^)([A-Z])", " $1");
            Console.WriteLine($"[{Convert.ToInt32(optionCategory)}] {displayName}");
        }
    }
}
