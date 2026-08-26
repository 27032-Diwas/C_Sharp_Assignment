using System.Globalization;
using System.Text.RegularExpressions;
using ConsoleTables;
using ExpenseTracker.Constants;
using ExpenseTracker.Helper;
using ExpenseTracker.Models;

namespace ExpenseTracker.View;

/// <summary>
/// Displays message to user and gets user input.
/// </summary>
public class TransactionView : IView
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
    /// Displays the details in transaction.
    /// </summary>
    /// <param name="transactions"> List of transaction to display. </param>
    public void DisplayTransactions(List<Transaction> transactions)
    {
        ConsoleTable contactTable = new ("S.No", "Date", "Amount", "Category", "Transaction Type", "Description");
        int i = 1;
        foreach (Transaction transaction in transactions)
        {
            DateOnly dateOnly = DateOnly.FromDateTime(transaction.Date);
            contactTable.AddRow(i++, dateOnly, transaction.Amount, transaction.Category, transaction.TransactionType, transaction.Description);
        }

        contactTable.Write();
    }

    /// <summary>
    /// Displays summary as table.
    /// </summary>
    /// <param name="summary"> Summary to be displayed. </param>
    public void DisplaySummary(string summary) => Console.WriteLine(summary);

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
    /// Gets description from the user.
    /// </summary>
    /// <returns> Description as a string. </returns>
    public string GetDescription()
    {
        string? description;
        while (true)
        {
            Console.WriteLine($"{UserPrompts.GetDescription} {UserPrompts.ExitProcess}");
            description = Console.ReadLine();

            if (description is null)
            {
                description = string.Empty;
            }

            if (!Validation.IsValidDescription(description))
            {
                this.DisplayErrorMessage(ErrorMessages.InvalidDescription);
                continue;
            }

            return description;
        }
    }

    /// <summary>
    /// Gets category from the user.
    /// </summary>
    /// <returns> Category as a string. </returns>
    public string GetCategory()
    {
        while (true)
        {
            string category = this.GetStringInput(UserPrompts.GetCategory);

            if (!Validation.IsValidCategory(category))
            {
                this.DisplayErrorMessage(ErrorMessages.InvalidCategory);
                continue;
            }

            return category;
        }
    }

    /// <summary>
    /// Gets amount from the user.
    /// </summary>
    /// <returns> Amount as decimal value. </returns>
    public decimal GetAmount()
    {
        while (true)
        {
            decimal amount = this.GetDecimalInput(UserPrompts.GetAmount);

            if (!Validation.IsValidAmount(amount))
            {
                this.DisplayErrorMessage(ErrorMessages.InvalidAmount);
                continue;
            }

            return amount;
        }
    }

    /// <summary>
    /// Gets date from the user.
    /// </summary>
    /// <returns> Date as datetime value. </returns>
    public DateTime GetDate()
    {
        string[] formats = { "dd-MM-yyyy", "dd-MM-yy", "yyyy-MM-dd", "yyyy-MM-dd HH:mm:ss" };

        while (true)
        {
            Console.WriteLine($"{UserPrompts.GetDate} {UserPrompts.ExitProcess}");
            string? userInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                this.DisplayErrorMessage(ErrorMessages.EmptyDate);
                continue;
            }

            if (userInput.Equals(HeaderMessages.Exit, StringComparison.OrdinalIgnoreCase))
            {
                throw new OperationCanceledException();
            }

            if (!DateTime.TryParseExact(userInput, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                this.DisplayErrorMessage(ErrorMessages.InvalidDate);
                continue;
            }

            if (!Validation.IsValidDate(date))
            {
                this.DisplayErrorMessage(ErrorMessages.FutureDate);
                continue;
            }

            return date;
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

    /// <summary>
    /// Gets input from user which is a valid number.
    /// </summary>
    /// <param name="prompt"> Message that needs to be displayed. </param>
    /// <returns> Null if user chooses to exit process; otherwise user input. </returns>
    private decimal GetDecimalInput(string prompt)
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

            if (!decimal.TryParse(userInput, out decimal decimalInput))
            {
                this.DisplayErrorMessage(ErrorMessages.InvalidNumber);
                continue;
            }

            return decimalInput;
        }
    }
}
