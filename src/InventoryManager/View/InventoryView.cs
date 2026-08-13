using System.Text.RegularExpressions;
using ConsoleTables;
using InventoryManager.Constants;
using InventoryManager.Models;

namespace InventoryManager.View;

/// <summary>
/// Display messages to user and gets input from user.
/// </summary>
public class InventoryView : IView
{
    /// <summary>
    /// Clear console.
    /// </summary>
    public void ClearConsole()
    {
        Console.Clear();
    }

    /// <summary>
    /// Displays the string passed as a parameter.
    /// </summary>
    /// <param name="message"> Message that needs to be displayed. </param>
    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }

    /// <summary>
    /// Gets input from user which is not null or empty.
    /// </summary>
    /// <param name="prompt"> Represents message displayed to user to get input. </param>
    /// <returns> Null if user chooses to exit process; otherwise user input. </returns>
    public string? GetStringInput(string prompt)
    {
        string? userInput;
        while (true)
        {
            Console.WriteLine($"{prompt} {UserPrompts.ExitProcess}");
            userInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine(ErrorMessages.InvalidString);
                continue;
            }

            if (userInput.ToUpper().Equals(HeaderMessages.Exit))
            {
                return null;
            }

            return userInput.Trim();
        }
    }

    /// <summary>
    /// Gets input from user which is a valid number.
    /// </summary>
    /// <param name="prompt"> Message that needs to be displayed. </param>
    /// <returns> Null if user chooses to exit process; otherwise user input. </returns>
    public decimal? GetDecimalInput(string prompt)
    {
        while (true)
        {
            Console.WriteLine($"{prompt} {UserPrompts.ExitProcess}");
            string? userInput = Console.ReadLine();
            if (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine(ErrorMessages.InvalidDigit);
                continue;
            }

            if (userInput.ToUpper().Equals(HeaderMessages.Exit))
            {
                return null;
            }

            if (!decimal.TryParse(userInput, out decimal decimalInput))
            {
                Console.WriteLine(ErrorMessages.InvalidDigit);
                continue;
            }

            return decimalInput;
        }
    }

    /// <summary>
    /// Gest input from user which is a valid long value.
    /// </summary>
    /// <param name="prompt"> Message that needs to be displayed. </param>
    /// <returns> Null if user chooses to exit process; otherwise user input. </returns>
    public long? GetLongInput(string prompt)
    {
        while (true)
        {
            Console.WriteLine($"{prompt} {UserPrompts.ExitProcess}");
            string? userInput = Console.ReadLine();
            if (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine(ErrorMessages.InvalidDigit);
                continue;
            }

            if (userInput.ToUpper().Equals(HeaderMessages.Exit))
            {
                return null;
            }

            if (!long.TryParse(userInput, out long longInput))
            {
                Console.WriteLine(ErrorMessages.InvalidDigit);
                continue;
            }

            return longInput;
        }
    }

    /// <summary>
    /// Displays list of products as a table.
    /// </summary>
    /// <param name="products"> List of products. </param>
    public void DisplayProducts(List<Product> products)
    {
        ConsoleTable contactTable = new ("S.No", "Product Id", "Product Name", "Product Price", "Product Quantity");
        int i = 1;
        foreach (Product product in products)
        {
            contactTable.AddRow(i++, product.ProductId, product.ProductName, product.ProductPrice, product.ProductQuantity);
        }

        contactTable.Write();
    }

    /// <summary>
    /// Waits for the user to press a key and then clears the console.
    /// </summary>
    public void GetAnyKey()
    {
        Console.WriteLine($"\n{UserPrompts.GetAnyKey}");
        Console.ReadKey();
        Console.Clear();
    }

    /// <summary>
    /// Gets a valid menu option selected by the user.
    /// </summary>
    /// <typeparam name="T"> The enumeration type. </typeparam>
    /// <param name="message"> The message displayed before the menu options. </param>
    /// <returns>
    /// The selected enumeration value.
    /// </returns>
    public T GetMenuChoice<T>(string message)
        where T : struct, Enum
    {
        while (true)
        {
            Console.WriteLine($"{message}\n");
            DisplayOptions<T>();
            Console.WriteLine($"\n{UserPrompts.SelectOption}");
            string input = string.Concat(Console.ReadLine()?.Where(c => !char.IsWhiteSpace(c)) ?? string.Empty);
            if (Enum.TryParse(input, true, out T choice) &&
                Enum.IsDefined(typeof(T), choice))
            {
                return choice;
            }

            Console.Clear();
            Console.WriteLine($"{ErrorMessages.InvalidOption}\n");
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
