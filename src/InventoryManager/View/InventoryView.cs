using ConsoleTables;
using InventoryManager.Constants;
using InventoryManager.EnumConstants;
using InventoryManager.Models;

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
            Console.WriteLine($"{prompt} {UserPrompts.ExitProcess}");
            userInput = Console.ReadLine();
            if (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine(ErrorMessages.InvalidString);
                continue;
            }

            if (userInput.ToUpper().Equals(HeaderMessages.Exit))
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
            Console.WriteLine($"{prompt} {UserPrompts.ExitProcess}");
            string? userInput = Console.ReadLine();
            if (string.IsNullOrEmpty(userInput))
            {
                return 0;
            }

            if (userInput.ToUpper().Equals(HeaderMessages.Exit))
            {
                return null;
            }

            if (!decimal.TryParse(userInput, out decimalInput))
            {
                Console.WriteLine(ErrorMessages.InvalidDigit);
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
            Console.WriteLine($"{prompt} {UserPrompts.ExitProcess}");
            string? userInput = Console.ReadLine();
            if (string.IsNullOrEmpty(userInput))
            {
                return 0;
            }

            if (userInput.ToUpper().Equals(HeaderMessages.Exit))
            {
                return null;
            }

            if (!int.TryParse(userInput, out integerInput))
            {
                Console.WriteLine(ErrorMessages.InvalidDigit);
                continue;
            }

            break;
        }
        while (true);
        return integerInput;
    }

    /// <summary>
    /// Displays list of products as a table.
    /// </summary>
    /// <param name="products"> List of products. </param>
    public static void DisplayProducts(List<Product> products)
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
    public static void GetAnyKey()
    {
        Console.WriteLine($"\n{UserPrompts.GetAnyKey}");
        Console.ReadKey();
        Console.Clear();
    }
}
