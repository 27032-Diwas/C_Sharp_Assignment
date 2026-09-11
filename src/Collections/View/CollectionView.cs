using System.Text.RegularExpressions;
using Collections.Constants;

namespace Collections.View;

/// <summary>
/// Displays message to user and gets user input.
/// </summary>
public class CollectionView : IView
{
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
            if (input.Equals(Configurables.QuitCommand, StringComparison.OrdinalIgnoreCase))
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
    /// Gets string input from user.
    /// </summary>
    /// <param name="prompt"> Message displayed to user to get input. </param>
    /// <returns> String input. </returns>
    public string GetStringInput(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                this.DisplayErrorMessage(ErrorMessages.EmptyString);
                continue;
            }

            if (input.Equals(Configurables.QuitCommand, StringComparison.OrdinalIgnoreCase))
            {
                throw new OperationCanceledException();
            }

            return input;
        }
    }

    /// <summary>
    /// Gets double input from user.
    /// </summary>
    /// <param name="prompt"> Message displayed to user to get input. </param>
    /// <returns> Double input. </returns>
    public double GetDoubleInput(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine(ErrorMessages.EmptyString);
                continue;
            }

            if (input.Equals(Configurables.QuitCommand, StringComparison.OrdinalIgnoreCase))
            {
                throw new OperationCanceledException();
            }

            if (!double.TryParse(input, out double value))
            {
                this.DisplayErrorMessage(ErrorMessages.InvalidNumber);
                continue;
            }

            return value;
        }
    }

    /// <summary>
    /// Gets integer input from user.
    /// </summary>
    /// <param name="prompt"> Message displayed to user to get input. </param>
    /// <returns> Integer input. </returns>
    public int GetIntegerInput(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine(ErrorMessages.EmptyString);
                continue;
            }

            if (input.Equals(Configurables.QuitCommand, StringComparison.OrdinalIgnoreCase))
            {
                throw new OperationCanceledException();
            }

            if (!int.TryParse(input, out int value))
            {
                this.DisplayErrorMessage(ErrorMessages.InvalidNumber);
                continue;
            }

            return value;
        }
    }

    /// <summary>
    /// Displays all values defined in the specific enum values.
    /// </summary>
    /// <typeparam name="T"> Type : enum </typeparam>
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
